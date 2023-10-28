using System.Collections;
using UnityEngine;

public class HealSkill : BaseSkill
{
    [SerializeField] float maxSpeed;
    public override void Influence()
    {
        HealTower healTower = ObjectPool.Instance.GetHealTower();
        healTower.SetHealTower(transform.position, damage, distance, maxSpeed);
        End();
    }
}
