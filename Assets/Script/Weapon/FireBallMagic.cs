using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMagic : BaseMagic
{
    private BaseEnemy nearestEnemy;
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
    
    protected override BaseEnemy FindEnemy()//��������Χ�еĵ���
    {
        List<BaseEnemy> enemies = EnemyManager.Instance.enemys;//���й����б�

        foreach (BaseEnemy enemy in enemies)//���������
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
        BaseEnemy target = FindEnemy();
        if (target != null)
        {
            Vector3 forward = ToolFunc.GetForward(gameObject, target.gameObject);
            FireBall bullet = ObjectPool.Instance.GetFireBall();
            bullet.setBullet(speed * forward, transform.position, damage, range);
        }
    }
    void LateUpdate()
    {
        // ��ÿ֡�����󽫾����޸�Ϊplayer�뵱ǰָ����˵ľ���
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
