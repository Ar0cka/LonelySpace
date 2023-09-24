using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class SlotSaved : ISlotSaved
{
    private bool _slot1Saved;

    private bool _slot2Saved;

    private bool _slot3Saved;

    public bool slot1Saved => _slot1Saved;
    public bool slot2Saved => _slot2Saved;
    public bool slot3Saved => _slot3Saved;

    public void CheckSlot(string fileName)
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        if (File.Exists(filePath))
        {
            if (fileName == "Slot1.txt") _slot1Saved = true;
            if (fileName == "Slot2.txt") _slot2Saved = true;
            if (fileName == "Slot3.txt") _slot3Saved = true;
        }
    }
    public void GetTrue(int index)
    {
        switch (index)
        {
            case 0: _slot1Saved = true; break;
            case 1: _slot2Saved = true; break;
            case 2: _slot3Saved = true; break;    
        }
    }
}
