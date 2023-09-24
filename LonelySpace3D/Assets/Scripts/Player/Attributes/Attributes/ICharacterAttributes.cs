using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterAttributes
{
    int Strength { get; }
    int Agility { get; }
    int Intelligence { get; }
    int Craft { get; }
    int Stealth { get; }
    int Garden { get;}

    int point { get; set; }

    void BeginAttributes();

    void IncreaseAttribute(int index);
    void DecreaseAttribute(int index);

    void SaveCharacterData (GameData characterData);
    void LoadCharacterData(GameData characterData);
}
