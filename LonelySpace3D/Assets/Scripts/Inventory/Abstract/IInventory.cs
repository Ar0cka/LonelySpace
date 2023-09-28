
using System;
using Unity.VisualScripting;

public interface IInventory  {
  
    int capacity { get; set; } // объем инвентаря
    bool isFull { get; } // проверка на заполненность инвентаря

    IInventoryItem GetItem(Type itemType); //выбор предмета
    IInventoryItem[] GetAllItems(); // выбор всех предметов
    IInventoryItem[] GetAllItems(Type itemType); // выбор предметов определенного типа
    IInventoryItem[] GetEquippedItems(); // выбрать предметы для обмундирования персонажа
    int GetItemAmount(Type itemType); // выбрать количество

    bool TryToAdd(object sender, IInventoryItem item); // проверка на то, успешно ли добавлены предметы, sender указывает, откуда предмет был взят.
    void Remove(object sender, Type itemType, int amount = 1); // удаление предметов определенного типа

    bool HasItem(Type type, out IInventoryItem item); // проверка существование предмета определенного типа



}
