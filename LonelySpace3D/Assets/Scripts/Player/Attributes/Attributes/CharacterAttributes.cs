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

    public int point { get; set; }

    public void BeginAttributes()
    {
        point = 10;
        strength = 0;
        agility = 0;
        intelligence = 0;
        craft = 0; 
        stealth = 0; 
        garden = 0;
    }
}
