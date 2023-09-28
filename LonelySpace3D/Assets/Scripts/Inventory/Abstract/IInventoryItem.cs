using System;
using Unity.VisualScripting;

public interface IInventoryItem 
{
    bool isEquipped { get; set; } // проверка, одевается ли предмет

    Type type { get; } //типа предмета
    int maxItemsInInventorySlot { get; } // сколько максимальное количество слотов
    int amount { get; set; } // количество

    IInventoryItem Clone(); // клонирование предмета

}
