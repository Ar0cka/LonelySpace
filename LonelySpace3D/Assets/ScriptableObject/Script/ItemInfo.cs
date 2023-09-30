using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New item", menuName = "Inventory/new Item")]
public class ItemInfo : ScriptableObject, IInventoryItemInfo
{
    [SerializeField] private string _idName;
    [SerializeField] private string _title;
    [SerializeField] private string _description;
    [SerializeField] private int _maxItemsInInventorySlot;
    [SerializeField] private Sprite _spriteIcon;


    public string idName => _idName;

    public string title => _title;
    public string description => _description;

    public int maxItemsInInventorySlot => _maxItemsInInventorySlot;

    public Sprite spriteIcon => _spriteIcon;
}
