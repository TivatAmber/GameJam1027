using System.Collections;
using System.Collections.Generic;
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
        if (timer > colldown)
        {
            timer = 0;
            Fire();
        }
        timer += Time.deltaTime;
    }

    protected override GameObject FindEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            // 矩形视野范围的宽度和高度
            float visionWidth = 10f;
            float visionHeight = 8f;

            // 获取玩家位置
            Vector3 playerPosition = transform.position;

            // 过滤出在玩家视野范围内的敌人
            List<GameObject> enemiesInVision = new List<GameObject>();
            foreach (GameObject enemy in enemies)
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
    protected override void Fire()//陨石攻击的逻辑和火球并不同我没有改
    {
        GameObject target = FindEnemy();
        if (target != null)
        {
            //TODO
        }
    }
    protected override void Upgrade()
    {
        // TODO
    }
}
