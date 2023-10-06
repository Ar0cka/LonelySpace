using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "itemData", menuName = "New item / Item" )]
public class CardInfo : ScriptableObject
{
    [SerializeField] private string _nameItem;
    [SerializeField] private string _descriptionItem;

    [SerializeField] private Sprite _spriteItem;

    [SerializeField] private float _weight;

    [SerializeField] private bool[] _levelAccess = new bool[3] { false, false, false };

    public string nameItem => _nameItem;
    public string descriptionItem => _descriptionItem;
    public Sprite spriteItem => _spriteItem;
    public float weight => _weight;
    public bool[] levelAccess => _levelAccess;
}
