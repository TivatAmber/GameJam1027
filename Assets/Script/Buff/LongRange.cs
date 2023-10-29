using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRange : BaseBuff
{
    [Range(0, 100)]
    [SerializeField] protected int deltaRangePercent;
    public override void UpGrade()
    {
        if (level < maxLevel)
        {
            WeaponManager.Instance.AddAllRange(deltaRangePercent);
        }
    }
}
