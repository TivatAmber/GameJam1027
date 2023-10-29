using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FireWallMagic : BaseMagic
{
    private BaseEnemy nearestEnemy;
    private float nearestDistance = Mathf.Infinity;
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

    protected override BaseEnemy FindEnemy()
    {
        List<BaseEnemy> enemies = EntityManager.Instance.enemies;//���й����б�

        if (nearestEnemy != null && !nearestEnemy.gameObject.activeSelf)
        {
            nearestEnemy = null;
        }
        foreach (BaseEnemy enemy in enemies)//���������
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (nearestEnemy == null || distance < nearestDistance)
            {
                nearestEnemy = enemy;
                nearestDistance = distance;
            }
        }
        return nearestEnemy;

    }
    protected override IEnumerator Fire()//���ε�aoe
    {
        for (int attackTime = 0; attackTime < combo; attackTime++)
        {
            BaseEnemy target = FindEnemy();
            if (target != null)
            {
                Vector3 forward = ToolFunc.GetForward(gameObject, target.gameObject);
                FireWall bullet = ObjectPool.Instance.GetFireWall();
                bullet.setBullet(speed * forward, transform.position, damage, range);
            }
            yield return new WaitForSeconds(0.5f);
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
                damage = 2;
                break;
            case 2:
                range = 2.5f;
                break;
            case 3:
                range = 3f;
                break;
            case 4:
                combo += 2;
                break;
        }
        if (level < maxLevel) level++;
    }
}
