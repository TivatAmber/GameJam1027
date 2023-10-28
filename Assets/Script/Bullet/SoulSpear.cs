using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSpear : BaseBullet
{
    List<BaseEnemy> enemyList = new List<BaseEnemy>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        TestCollision(target);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        RemoveCollsion(target);
    }
    private void TestCollision(GameObject target)
    {
        if (target != null && target.CompareTag("Enemy"))
        {
            if (target.TryGetComponent<BaseEnemy>(out var enemy))
            {
                if (!enemyList.Contains(enemy))
                {
                    enemyList.Add(enemy);
                }
            }
        }
    }
    private void RemoveCollsion(GameObject target)
    {
        if (target != null && target.CompareTag("Enemy"))
        {
            if (target.TryGetComponent<BaseEnemy>(out var enemy))
            {
                if (enemyList.Contains(enemy))
                {
                    enemyList.Remove(enemy);
                }
            }
        }
    }
    public void Attack()
    {
        List<BaseEnemy> targets = new List<BaseEnemy>();
        foreach (BaseEnemy enemy in enemyList)
        {
            if (enemy != null && enemy.gameObject.activeSelf)
            {
                targets.Add(enemy);
            }
        }
        foreach (BaseEnemy enemy in targets)
        {
            enemy.ChangeHealth(damage);
        }
    }
    public void End()
    {
        ObjectPool.Instance.DestroyBullet(this);
    }
}
