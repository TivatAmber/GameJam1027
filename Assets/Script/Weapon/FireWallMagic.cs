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
        if (timer > colldown)
        {
            timer = 0;
            Fire();
        }
        timer += Time.deltaTime;
    }

    protected override GameObject FindEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");//���й����б�

        foreach (GameObject enemy in enemies)//���������
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
    protected override void Fire()//���ε�aoe
    {
        GameObject target = FindEnemy();
        if (target != null)
        {
            Vector3 forward = target.transform.position - gameObject.transform.position;
            forward.Normalize();
            GameObject obj = ObjectPool.Instance.GetFireBall();
            FireBall bullet = obj.GetComponent<FireBall>();
            bullet.Speed = speed * forward;
            bullet.Damage = damage;
            bullet.transform.position = gameObject.transform.position;
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
