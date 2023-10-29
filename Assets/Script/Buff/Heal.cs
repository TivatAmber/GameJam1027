using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : BaseBuff
{
    [SerializeField] private int deltaHealth;

    public override void UpGrade()
    {
        if (level < maxLevel)
        {
            level++;
            EntityManager.Instance.player.ChangeHealth(-deltaHealth);
        }
    }
}
