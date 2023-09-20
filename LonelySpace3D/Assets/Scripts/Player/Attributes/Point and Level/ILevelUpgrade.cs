using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelUpgrade
{
    int Level { get; }
    float experience { get; set; }

    void BeginLevelAndExp();
}
