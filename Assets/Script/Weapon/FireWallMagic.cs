using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWallMagic : BaseMagic
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

    protected override GameObject FindEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");//所有怪物列表

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
    protected override void Fire()//矩形的aoe
    {
        GameObject target = FindEnemy();
        if (target != null)
        {
            // TODO
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
