using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMagic : BaseMagic
{
    private GameObject nearestEnemy;
    private float nearestDistance = Mathf.Infinity;
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
    
    protected override GameObject FindEnemy()//搜索自身范围中的敌人
    {
        //第一等级索敌
        //TODO
        //第二等级索敌
        List<GameObject> enemies = EnemyManager.Instance.enemys;//所有怪物列表

        foreach (GameObject enemy in enemies)//搜索最近的
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < nearestDistance)
            {
                nearestEnemy = enemy;
                nearestDistance = distance;
            }
        }
        return nearestEnemy;
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
    void LateUpdate()
    {
        // 在每帧结束后将距离修改为player与当前指向敌人的距离
        if (nearestEnemy != null)
        {
            nearestDistance = Vector3.Distance(transform.position, nearestEnemy.transform.position);
        }
    }
    protected override void Upgrade()
    {
        // TODO
    }
}
