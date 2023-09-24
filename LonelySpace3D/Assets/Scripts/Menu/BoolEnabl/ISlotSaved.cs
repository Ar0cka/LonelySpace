using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISlotSaved 
{
    bool slot1Saved { get; }
    bool slot2Saved { get; }
    bool slot3Saved { get; }

    void CheckSlot(string fileName);

    void GetTrue(int index);
}
