using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : BaseEnemy
{
    new private void Start()
    {
        base.Start();
        timer = attackCooldown;
    }
    private void Update()
    {
        Move();
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
    protected override void Move()
    {
        Vector3 forward = ToolFunc.GetForward(gameObject, EntityManager.Instance.player.gameObject);
        speed = forward * maxSpeed;
        transform.position += speed * Time.deltaTime;
    }
    public void Init()
    {
        health = maxHealth;
        timer = attackCooldown;
    }
}
