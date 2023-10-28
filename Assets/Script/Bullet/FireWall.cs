using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : BaseBullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        TestCollsion(target);
    }
    void TestCollsion(GameObject target)
    {
        if (target != null && target.tag == "Enemy")
        {
            BaseEnemy targetHealth = target.GetComponent<BaseEnemy>();
            if (targetHealth != null)
            {
                targetHealth.ChangeHealth(damage);
            }
        }
    }
    private void Update()
    {
        transform.position += speed;
    }
}
