using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterAttributes
{
    int strength { get; set; }
    int agility { get; set; }
    int intelligence { get; set; }
    int craft { get; set; }
    int stealth { get; set; }
    int garden { get; set; }

    void BeginAttributes();
}
