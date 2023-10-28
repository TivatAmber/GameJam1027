using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : BaseEnemy
{
    private void Update()
    {
        if (timer < attackCooldown)
        {
            timer += Time.deltaTime;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject target = collision.gameObject;
        TestCollsion(target);
    }
    void TestCollsion(GameObject target)
    {
        if (target != null && target.tag == "Player")
        {
            Player player = target.GetComponent<Player>();
            if (player != null && timer >= attackCooldown)
            {
                player.ChangeHealth(damage);
                timer = 0;
            }
        }
    }
}
