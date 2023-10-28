using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugeSoulSpearSkill : BaseSkill
{
    [SerializeField] float range;
    public override void Influence()
    {
        HugeSoulSpear hugeSoulSpear = ObjectPool.Instance.GetHugeSoulSpear();
        hugeSoulSpear.setHugeSoulSpear(transform.position, damage, distance, range);
        End();
    }
    void Update()
    {
        Debug.DrawLine(transform.position, EntityManager.Instance.player.transform.position);
    }
}
