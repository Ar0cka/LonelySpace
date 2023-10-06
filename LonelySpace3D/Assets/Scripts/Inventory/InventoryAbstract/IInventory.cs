using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory
{
    bool isFull { get; }
    int capacityWeight { get; set; }
    int level { get; set; }
    List<IInventorySlot> slots { get; set; }
    int amountSlot { get; set; }

    void InventoryLevelUP();
    void CalculatingTheTotalWeight();

}
