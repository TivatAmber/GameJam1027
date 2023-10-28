using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tears : BaseBullet
{
    Animator animator;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public override void setBullet(Vector3 postision, int damage, float range)
    {
        animator.Play("Fall");
        base.setBullet(postision, damage, range);
    }
    public void Boom()
    {
        List<BaseEnemy> enemies = EntityManager.Instance.enemies;
        List<BaseEnemy> targets = new List<BaseEnemy>();
        foreach (BaseEnemy enemy in enemies)
        {
            if (ToolFunc.Dist(transform.position, enemy.transform.position) < range)
            {
                targets.Add(enemy);
            }
        }
        foreach (BaseEnemy enemy in targets)
        {
            if (enemy.TryGetComponent<BaseEnemy>(out var enemyHealth))
            {
                enemyHealth.ChangeHealth(damage);
            }
        }
    }
    public void End()
    {
        ObjectPool.Instance.DestroyBullet(this);
    }
}
