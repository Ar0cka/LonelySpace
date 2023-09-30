
using JetBrains.Annotations;
using UnityEngine;

public interface IInventoryItemInfo 
{
    string idName { get; }
    string title { get; }
    string description { get; } 
    int maxItemsInInventorySlot { get; }

    Sprite spriteIcon { get; }
}
