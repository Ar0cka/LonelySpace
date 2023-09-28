

using System;

public class InventorySlot : IInventorySlot
{
    public bool isFull => amount == capacity; // если isFull больше или равен amount, при этом amount = capacity, тогда true, где capacity - это максимальный объем 

    public bool isEmpty => item == null; // isEmpty = true тогда, когда item == null;

    public IInventoryItem item { get; private set; } // свойство с публичной читаемостью и приватным изменением

    public Type itemType => item.type; //itemType = типу предмета

    public int amount => isEmpty ? 0 : item.amount; // если isEmpty вернуть 0, нужно чтобы не возвращало null;

    public int capacity {get; private set;} // объем слота

    public void Clear()
    {
        if (!isEmpty) return;

        item.amount = 0;
        item = null;
    }

    public void SetItem(IInventoryItem item)
    {
        if (!isEmpty) return;

        this.item = item;
        this.capacity = item.maxItemsInInventorySlot;
    }
}
