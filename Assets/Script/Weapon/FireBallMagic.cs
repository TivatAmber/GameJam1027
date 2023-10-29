using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBallMagic : BaseMagic
{
    private BaseEnemy nearestEnemy;
    private float nearestDistance = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
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
    
    protected override BaseEnemy FindEnemy()//��������Χ�еĵ���
    {
        List<BaseEnemy> enemies = EntityManager.Instance.enemies;//���й����б�

        foreach (BaseEnemy enemy in enemies)//���������
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < nearestDistance)
            {
                nearestEnemy = enemy;
                nearestDistance = distance;
            }
        }
        if (nearestEnemy != null && !nearestEnemy.gameObject.activeSelf)
        {
            nearestEnemy = null;
        }
        return nearestEnemy;
    }
    protected override IEnumerator Fire()
    {
        lock (EntityManager.Instance.enemies)
        {
            for (int attackTime = 0; attackTime < combo; attackTime++)
            {
                BaseEnemy target = FindEnemy();
                if (target != null)
                {
                    Vector3 forward = ToolFunc.GetForward(gameObject, target.gameObject);
                    FireBall bullet = ObjectPool.Instance.GetFireBall();
                    bullet.setBullet(speed * forward, transform.position, damage, range);
                }
                yield return new WaitForSeconds(0.1f);
            }
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
    public override void UpGrade()
    {
        switch (level)
        {
            case 1:
                combo++;
                break;
            case 2:
                combo++;
                break;
            case 3:
                damage = 3;
                break;
            case 4:
                cooldown = 0.5f;
                break;
        }
        if (level < maxLevel) level++;
    }
}
