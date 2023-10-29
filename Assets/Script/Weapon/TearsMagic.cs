using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TearsMagic : BaseMagic
{
    void Start()
    {
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

    protected override BaseEnemy FindEnemy()
    {
        List<BaseEnemy> enemies = EntityManager.Instance.enemies;//所有怪物列表

        if (enemies.Count > 0)
        {
            // 矩形视野范围的宽度和高度
            float visionWidth = 10f;
            float visionHeight = 8f;

            // 获取玩家位置
            Vector3 playerPosition = transform.position;

            // 过滤出在玩家视野范围内的敌人
            List<BaseEnemy> enemiesInVision = new List<BaseEnemy>();
            foreach (BaseEnemy enemy in enemies)
            {
                Vector3 enemyPosition = enemy.transform.position;
                Vector3 enemyDirection = enemyPosition - playerPosition;

                // 计算敌人相对于玩家的 x 和 y 轴距离
                float enemyDistanceX = Vector3.Dot(enemyDirection, transform.right);
                float enemyDistanceY = Vector3.Dot(enemyDirection, transform.up);

                if (Mathf.Abs(enemyDistanceX) <= visionWidth && Mathf.Abs(enemyDistanceY) <= visionHeight)
                {
                    enemiesInVision.Add(enemy);
                }
            }

            if (enemiesInVision.Count > 0)
            {
                int randomIndex = Random.Range(0, enemiesInVision.Count);
                return enemiesInVision[randomIndex];
            }
        }

        return null;
    }
    protected override IEnumerator Fire()//陨石攻击的逻辑和火球并不同我没有改
    {
        for (int attackTime = 0; attackTime < combo; attackTime++)
        {
            BaseEnemy target = FindEnemy();
            if (target != null)
            {
                Tears bullet = ObjectPool.Instance.GetTears();
                bullet.setBullet(target.transform.position, damage, range);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    public override void UpGrade()
    {
        switch (level)
        {
            case 1:
                combo += 1;
                break;
            case 2:
                range += 1.0f;
                break;
            case 3:
                combo += 3;
                break;
            case 4:
                cooldown = 4;
                break;
        }
        if (level < maxLevel) level++;
    }
}
