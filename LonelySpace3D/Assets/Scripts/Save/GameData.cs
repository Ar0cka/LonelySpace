using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int strength;
    public int agility;
    public int intelligence;
    public int craft;
    public int stealth;
    public int garden;
    public int point;
}
[System.Serializable]
public class SlotSavedData
{
    public bool slot1Saved;
    public bool slot2Saved;
    public bool slot3Saved;

    public SlotSavedData(bool slot1Saved, bool slot2Saved, bool slot3Saved)
    {
        this.slot1Saved = slot1Saved;
        this.slot2Saved = slot2Saved;
        this.slot3Saved = slot3Saved;
    }
}
