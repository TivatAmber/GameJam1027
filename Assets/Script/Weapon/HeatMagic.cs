using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatMagic : BaseMagic
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

    protected override BaseEnemy FindEnemy()//搜索自身范围中的敌人
    {
        return null;
    }
    protected override void Fire()//对所有敌人
    {
        List<BaseEnemy> enemies = EntityManager.Instance.enemies;
        List<BaseEnemy> targets = new List<BaseEnemy>();
        foreach (BaseEnemy enemy in enemies)
        {
            if (ToolFunc.Dist(transform.position, enemy.transform.position) < range)
            {
                targets.Add(enemy);
            }
        }
        foreach (BaseEnemy enemy in targets)
        {
            if (enemy.TryGetComponent<BaseEnemy>(out var enemyHealth))
            {
                enemyHealth.ChangeHealth(damage);
            }
        }
    }
    protected override void Upgrade()
    {
        // TODO
    }
}
