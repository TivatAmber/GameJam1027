using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radius : BaseBuff
{
    [SerializeField] private int deltaGetExpRange;
    public override void UpGrade()
    {
        if (level < maxLevel)
        {
            EntityManager.Instance.player.AddGetExpRange(deltaGetExpRange);
        }
    }
}
