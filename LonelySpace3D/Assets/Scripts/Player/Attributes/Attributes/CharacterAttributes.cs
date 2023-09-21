using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttributes : ICharacterAttributes
{
    #region initialize
    private int strength;
    private int agility;
    private int intelligence;
    private int craft;
    private int stealth;
    private int garden;
    
    public int Strength => strength;
    public int Agility => agility;
    public int Intelligence => intelligence;
    public int Craft => craft;
    public int Stealth => stealth;
    public int Garden => garden;

    public int point { get; set; }
    #endregion
    public void BeginAttributes()
    {
        point = 10;
        strength = 2;
        agility = 1;
        intelligence = 3;
        craft = 2; 
        stealth = 1; 
        garden = 1;
    }
    #region Increase and decrease Attributes
    public void IncreaseAttribute(int index)
    {
        if (point > 0)
        {
            switch (index)
            {
                case 0:
                    strength += 1;
                    point -= 1; break;
                case 1:
                    agility += 1;
                    point -= 1; break;
                case 2:
                    intelligence += 1;
                    point -= 1; break;
                case 3:
                    craft += 1;
                    point -= 1; break;
                case 4:
                    stealth += 1;
                    point -= 1; break;
                case 5:
                    garden += 1;
                    point -= 1; break;
            }
        }
    }
    public void DecreaseAttribute(int index)
    {
            switch (index)
            {
            case 0:
                if (strength > 0)
                {
                    strength -= 1;
                    point += 1;
                }
                break; //Decrease strength
            case 1:
                if (agility > 0)
                {
                    agility -= 1;
                    point += 1;
                }
                break; //Decrease agility
            case 2:
                if (intelligence > 0)
                {
                    intelligence -= 1;
                    point += 1;
                }
                break; //Decrease intelligence
            case 3:
                if (craft > 0)
                {
                    craft -= 1;
                    point += 1;
                }
                break; //Decrease craft
            case 4:
                if (stealth > 0)
                {
                    stealth -= 1;
                    point += 1;
                }
                break; //Decrease stealth
            case 5:
                if (garden > 0)
                {
                    garden -= 1;
                    point += 1;
                }
                break; //Decrease garden
        }
    }
    #endregion

    #region SaveAndLoadCharacterData
    public void SaveCharacterData(CharacterAttributesData characterData)
    {
        characterData.strength = strength;
        characterData.agility = agility;
        characterData.intelligence = intelligence;
        characterData.craft = craft;
        characterData.stealth = stealth;    
        characterData.garden = garden;  
        characterData.point = point;
    }
    public void LoadCharacterData(CharacterAttributesData characterData)
    {
        strength = characterData.strength;
        agility = characterData.agility;    
        intelligence = characterData.intelligence;
        craft = characterData.craft;
        stealth = characterData.stealth;
        garden = characterData.garden;
        point = characterData.point;    
    }
    #endregion
}
