using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttributes : ICharacterAttributes
{
    public int strength { get; set; }
    public int agility { get; set; }
    public int intelligence { get; set; }
    public int craft { get; set; }
    public int stealth { get; set; }
    public int garden { get; set; }

    public void BeginAttributes()
    {
        strength = 1;
        agility = 2;
        intelligence = 4;
        craft = 3; 
        stealth = 5; 
        garden = 3;
    }
}
