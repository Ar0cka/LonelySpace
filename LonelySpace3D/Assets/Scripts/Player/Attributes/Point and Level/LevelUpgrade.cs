using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpgrade : ILevelUpgrade
{
    private int level;

    public int Level => level;

    public float experience { get; set; }

    public void BeginLevelAndExp()
    {
        level = 0;
        experience = 0;
    }
}
