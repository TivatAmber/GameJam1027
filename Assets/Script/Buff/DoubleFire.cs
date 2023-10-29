using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleFire : BaseBuff
{
    [SerializeField] private int deltaCombo;
    public override void UpGrade()
    {
        if (level < maxLevel)
        {
            level++;
            WeaponManager.Instance.AddAllCombo(deltaCombo);
        }
    }
}
