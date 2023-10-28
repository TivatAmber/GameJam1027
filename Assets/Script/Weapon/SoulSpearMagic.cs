using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSpearMagic : BaseMagic
{
    private void Start()
    {
        timer = 0;
    }
    private void Update()
    {
        if (timer > cooldown)
        {
            timer = 0;
            Fire();
        }
        timer += Time.deltaTime;
    }
    protected override BaseEnemy FindEnemy()
    {
        return null;
    }
    protected override void Fire()
    {
        Vector3 forward = Vector3.zero;
        if (EntityManager.Instance.player.forward.magnitude > 0)
        {
            forward = EntityManager.Instance.player.forward * range;
        }
        SoulSpear soulSpear = ObjectPool.Instance.GetSoulSpear();
        soulSpear.setBullet(transform.position + forward, damage);
    }
    protected override void Upgrade()
    {
        // TODO
    }
}
