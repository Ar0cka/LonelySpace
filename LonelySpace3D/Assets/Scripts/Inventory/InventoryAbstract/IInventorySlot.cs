using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventorySlot
{
    bool isFull { get; }
    bool isEmpty { get; }
    int capacity { get; }
    int amount { get; }

    void AddItemInSlot(Sprite icon, int amount);
    void RemoveItemInSlot(Sprite icon, int amount);
    void SearchEmptySlot();
    void GetSlot();
}
