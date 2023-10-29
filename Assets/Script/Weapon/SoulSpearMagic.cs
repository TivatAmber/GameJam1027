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
        if (level > 0 && timer > cooldown)
        {
            timer = 0;
            StartCoroutine(Fire());
        }
        timer += Time.deltaTime;
    }
    protected override BaseEnemy FindEnemy()
    {
        return null;
    }
    protected override IEnumerator Fire()
    {
        int flag = 1;
        lock (EntityManager.Instance.enemies)
        {
            for (int attackTime = 0; attackTime < combo; attackTime++)
            {
                Vector3 forward = Vector3.right * range;
                if (EntityManager.Instance.player.forward.magnitude > 0)
                {
                    forward = EntityManager.Instance.player.forward * range;
                }
                forward = new Vector3(forward.x * flag, 0, 0);
                SoulSpear soulSpear = ObjectPool.Instance.GetSoulSpear();
                soulSpear.setBullet(transform.position + forward, damage);

                soulSpear.transform.localScale = new Vector3(1, forward.x * flag, 0);

                flag *= -1;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
    public override void UpGrade()
    {
        switch (level)
        {
            case 1:
                combo++;
                break;
            case 2:
                damage = 3;
                break;
            case 3:
                combo++;
                break;
            case 4:
                damage = 4;
                break;
        }
        if (level < maxLevel) level++;
    }
}
