using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMagic : BaseMagic
{
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > cooldown)
        {
            timer = 0;
            Fire();
        }
        timer += Time.deltaTime;
    }
    protected override GameObject FindEnemy()
    {
        GameObject target = null;
        float dist = range;
        foreach(GameObject enemy in EnemyManager.Instance.enemys)
        {
            if (enemy == null) continue;
            float tmp = ToolFunc.Dist(enemy.transform.position, gameObject.transform.position);
            if (tmp < dist) {
                dist = tmp;
                target = enemy;
            }
        }
        return target;
    }
    protected override void Fire()
    {
        GameObject target = FindEnemy();
        if (target != null)
        {
            Vector3 forward = target.transform.position - gameObject.transform.position;
            forward.Normalize();
            FireBall bullet = ObjectPool.Instance.GetFireBall();
            bullet.Speed = speed * forward;
            bullet.Damage = damage;
            bullet.transform.position = gameObject.transform.position;
        }
    }
    protected override void Upgrade()
    {
        // TODO
    }
}
