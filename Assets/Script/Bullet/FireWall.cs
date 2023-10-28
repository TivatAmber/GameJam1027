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
        if (target != null && target.CompareTag("Enemy"))
        {
            if (target.TryGetComponent<BaseEnemy>(out var targetHealth))
            {
                targetHealth.ChangeHealth(damage);
            }
        }
    }
    private void Update()
    {
        transform.position += speed;
        if ((transform.position - originPosition).magnitude > range)
        {
            ObjectPool.Instance.DestroyBullet(this);
        }
    }
}
