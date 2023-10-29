using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : BaseBuff
{
    [Range(0, 100)]
    [SerializeField] private int deltaCoolTimePercent; 
    public override void UpGrade()
    {
        if (level < maxLevel)
        {
            level++;
            WeaponManager.Instance.SubAllCoolTime(deltaCoolTimePercent);
        }
    }
}
