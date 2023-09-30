
using System;

public interface IInventorySlot {
  
    bool isFull { get; } // проверка на полн ли слот
    bool isEmpty { get; }  // проверка пуст ли слот

    IInventoryItem item { get; } // сам предмет
    Type itemType { get; } // тип предмета
    int amount { get; } // количество предмета
    int capacity { get; } // максимальный объем слота

    void SetItem(IInventoryItem item); // выбор предмета
    void Clear(); //очистка
}
