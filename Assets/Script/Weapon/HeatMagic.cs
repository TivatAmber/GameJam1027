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

    protected override BaseEnemy FindEnemy()//��������Χ�еĵ���
    {
        return null;
    }
    protected override void Fire()//�����е���
    {
        List<BaseEnemy> enemys = new List<BaseEnemy> ();

        foreach (BaseEnemy enemy in EnemyManager.Instance.enemys)
        {
            BaseEnemy enemyHealth = enemy.GetComponent<BaseEnemy>();
            if (ToolFunc.Dist(enemy.transform.position, transform.position) < range && enemyHealth != null)
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
