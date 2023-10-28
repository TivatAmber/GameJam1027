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
        if (timer > cooldown)
        {
            timer = 0;
            Fire();
        }
        timer += Time.deltaTime;
    }

    protected override BaseEnemy FindEnemy()
    {
        List<BaseEnemy> enemies = EntityManager.Instance.enemies;//���й����б�

        if (enemies.Count > 0)
        {
            // ������Ұ��Χ�Ŀ�Ⱥ͸߶�
            float visionWidth = 10f;
            float visionHeight = 8f;

            // ��ȡ���λ��
            Vector3 playerPosition = transform.position;

            // ���˳��������Ұ��Χ�ڵĵ���
            List<BaseEnemy> enemiesInVision = new List<BaseEnemy>();
            foreach (BaseEnemy enemy in enemies)
            {
                Vector3 enemyPosition = enemy.transform.position;
                Vector3 enemyDirection = enemyPosition - playerPosition;

                // ��������������ҵ� x �� y �����
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
    protected override void Fire()//��ʯ�������߼��ͻ��򲢲�ͬ��û�и�
    {
        BaseEnemy target = FindEnemy();
        if (target != null)
        {
            Tears bullet = ObjectPool.Instance.GetTears();
            bullet.setBullet(target.transform.position, damage, range);
        }
    }
    protected override void Upgrade()
    {
        // TODO
    }
}
