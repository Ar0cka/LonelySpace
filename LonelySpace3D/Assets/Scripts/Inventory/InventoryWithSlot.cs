using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class InventoryWithSlot : IInventory
{
    public event Action<object, IInventoryItem, int> OnInventoryItemAddedEvent;
    public event Action<object, Type , int> OnInventoryItemRemovedEvent;
    public event Action<object> OnInventoryStateChangeEvent;

    public int capacity { get; set; } // общий объекм инвентаря

    public bool isFull => _slots.All(slot => slot.isFull);

    private List<IInventorySlot> _slots; // лист со слотами
 
    public InventoryWithSlot(int capacity) // конструктор класса
    {
        this.capacity = capacity;
        _slots = new List<IInventorySlot>(capacity);// создание нового списка со слотами
        for (int i = 0; i < capacity; i++)
            _slots.Add(new InventorySlot()); // добавление слотов
    }

    public IInventoryItem GetItem(Type itemType)
    {
        return _slots.Find(slot => slot.itemType == itemType).item; // поиск предмета определенного типа
    }

    public IInventoryItem[] GetAllItems()
    {
        var allItems = new List<IInventoryItem>(); // List в котором будут сохранены все Items
        foreach (var slot in _slots)
        {
            if (!slot.isEmpty)
                allItems.Add(slot.item); // запись данных в список
        }
        return allItems.ToArray(); //возвращение листа
    }

    public IInventoryItem[] GetAllItems(Type itemType)
    {
        var allItemsOfTypes = new List<IInventoryItem>(); // лист со всеми предметами определенного типа
        var slotTypes = _slots.FindAll(slot => !slot.isEmpty && slot.itemType == itemType); // поиск слота определенного типа и не равного null
 
        foreach (var slot in slotTypes)
        {
            if (!slot.isEmpty)
                allItemsOfTypes.Add(slot.item); // добавление данных в слот
        }
        return allItemsOfTypes.ToArray(); 
    }

    public IInventoryItem[] GetEquippedItems()
    {
        var requiredSlots = _slots.FindAll(slot => slot.item.state.isEquipped && !slot.isEmpty); // поиск предметов имеющие isEquipped и не пустые
        var equippedItems = new List<IInventoryItem>();

        foreach (var slot in requiredSlots)
        {
           equippedItems.Add(slot.item); // добавление в List
        }
        return equippedItems.ToArray();
    }

    public int GetItemAmount(Type itemType)
    {
        var amount = 0; 
        var allItemSlots = _slots.FindAll(slot=>!slot.isEmpty && slot.itemType == itemType);

        foreach (var slot in allItemSlots)
            amount += slot.amount;
        return amount;
    }

    public bool TryToAdd(object sender, IInventoryItem item)
    {
        var slotWithSameItemButNotEmpty = _slots.Find(slot => slot.item == item && !slot.isEmpty && !slot.isFull); // если слот не полный и не пустой
        if (slotWithSameItemButNotEmpty != null)
            return TryToAddToSlot(sender, slotWithSameItemButNotEmpty, item); //добавление в слот предметы если слот имеет уже в себе предметы

        var emptySlot = _slots.Find(slot => slot.isEmpty); // создания пустого слота
        if (emptySlot != null)
            return TryToAddToSlot(sender, emptySlot, item); // добавление в пустой слот

        Debug.Log("Инвентарь полный");
        return false; // если в инвентаре нет пустых ячеек и все заполнено, тогда возвращается False
    }

    public bool TryToAddToSlot(object sender, IInventorySlot slot, IInventoryItem item) {

        var fits = slot.amount + item.state.amount <= item.info.maxItemsInInventorySlot; // добавление в слот, если сумма слота и сумма предметов меньше или равна максимальному значению ячейки
        
        var amountToAdd = fits ? item.state.amount : item.info.maxItemsInInventorySlot - slot.amount;

        var amountLeft = item.state.amount - amountToAdd; // остаток
        var clonedItem = item.Clone(); // клонирование предмета

        clonedItem.state.amount = amountToAdd; // прибавление к клонированному предмету, остаток

        if (slot.isEmpty)
            slot.SetItem(clonedItem); // если слот пустой, добавить туда клонированный предмет
        else
            slot.item.state.amount += amountToAdd; // иначе прибавление к amount слота

        Debug.Log("Item added to inventory. Item type: " + item.type + " amount " + item.state.amount);
        OnInventoryItemAddedEvent?.Invoke(sender, item, amountToAdd);
        OnInventoryStateChangeEvent?.Invoke(sender);

        if (amountLeft <= 0)
            return true; // если нет остатка, вернуть тру

        item.state.amount = amountLeft; // если есть остаток, то мы добавляем остаток в инвентарь
        return TryToAdd(sender, item);

    }

    public void TransitFromSlotToSlot(object sender, IInventorySlot fromSlot, IInventorySlot toSlot)
    {
        if (fromSlot.isEmpty)
            return;
        

        if (toSlot.isFull)
            return;

        
        if (!toSlot.isEmpty && fromSlot.itemType == toSlot.itemType)
            return;

        var slotCapacity = fromSlot.capacity;
        var fits = fromSlot.amount + toSlot.amount <= slotCapacity;
        var amountToAdd = fits ? fromSlot.amount : slotCapacity - toSlot.amount;
        var amountLeft = fromSlot.amount - amountToAdd;

        if (toSlot.isEmpty){
            toSlot.SetItem(fromSlot.item);
            fromSlot.Clear();
            OnInventoryStateChangeEvent?.Invoke(sender);
        }

        toSlot.item.state.amount += amountToAdd;
        if (fits)
            fromSlot.Clear();
        else
            fromSlot.item.state.amount = amountLeft;
        OnInventoryStateChangeEvent?.Invoke(sender);
    }
    public bool HasItem(Type type, out IInventoryItem item)
    {
        item = GetItem(type); // выбор предмета по его типу
        return item != null;
    }

    public void Remove(object sender, Type itemType, int amount = 1) // удаление слотов
    {
        var slotsWithItem = GetAllSlots(itemType); // установка всех слотов определенного типа
        if (slotsWithItem.Length == 0) // проверка на количество слотов
            return;

        var amountToRemove = amount; // количество которое нужно удалить
        var count = slotsWithItem.Length; // количество предметов в слоте

        for (int i = count - 1; i >= 0; i--)
        {
            var slot = slotsWithItem[i]; 
            if (slot.amount >= amountToRemove) {
                slot.item.state.amount -= amountToRemove; // вычитание из слота, определенные предметы

                if (slot.amount == 0)
                    slot.Clear(); // очистка слота, если он равен 0
                OnInventoryStateChangeEvent?.Invoke(sender);
                OnInventoryItemRemovedEvent?.Invoke(sender, itemType, amountToRemove);

                break;
            }
            var amountRemoved = slot.amount;
            amountToRemove -= slot.amount; // проверка остатка
            slot.Clear(); //очистка
            OnInventoryItemRemovedEvent?.Invoke(sender, itemType, amountRemoved);
            OnInventoryStateChangeEvent?.Invoke(sender);
        }
    }

    public IInventorySlot[] GetAllSlots(Type itemType) // выбрать слот
    {
        return _slots.FindAll(slot => !slot.isEmpty && slot.itemType == itemType).ToArray();
    }

    public IInventorySlot[] GetAllSlots() // выбрать все слоты
    {
        return _slots.ToArray();
    }
}
