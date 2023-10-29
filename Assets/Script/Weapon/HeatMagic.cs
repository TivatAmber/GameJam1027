using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatMagic : BaseMagic
{
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (level > 0 && timer > cooldown)
        {
            timer = 0;
            StartCoroutine(Fire());
        }
        timer += Time.deltaTime;
    }

    protected override BaseEnemy FindEnemy()//搜索自身范围中的敌人
    {
        return null;
    }
    protected override IEnumerator Fire()//对所有敌人
    {
        for (int attackTime = 0; attackTime < combo; attackTime++)
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
            yield return new WaitForSeconds(0.1f);
        }
    }
    public override void UpGrade()
    {
        switch (level)
        {
            case 1:
                cooldown = 0.5f;
                break;
            case 2:
                range = 2.5f;
                break;
            case 3:
                range = 3;
                break;
            case 4:
                damage += 1;
                break;
        }
        if (level < maxLevel) level++;
    }
}
