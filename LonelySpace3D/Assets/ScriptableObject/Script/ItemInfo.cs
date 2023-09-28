using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Inventory/new Item")]
public class ItemInfo : ScriptableObject
{ 
    [SerializeField] private string _itemName;
    [SerializeField] private int _itemID;
    [SerializeField] private Sprite _spriteItem;

    public string ItemName => this._itemName;
    public int ItemID => this._itemID;
    public Sprite SpriteItem => this._spriteItem;

}
