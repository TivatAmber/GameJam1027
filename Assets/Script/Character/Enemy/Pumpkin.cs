using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : BaseEnemy
{
    Player player;
    [SerializeField] float boomR;
    [SerializeField] int boomDemage;
    [SerializeField] float boomDelay;
    Vector3 diedPosition;
    new private void Start()
    {
        boomDemage = 5;
        boomR = 1;
        boomDelay = 5f;
        base.Start();
        player = EntityManager.Instance.player;
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
    protected override void Die()
    {
        diedPosition = transform.position;
        // µœ÷5√Î∫Û±¨’®
        StartCoroutine(ExplodeAfterDelay(boomDelay, diedPosition));
        base.Die();

    }
    private IEnumerator ExplodeAfterDelay(float delay, Vector3 position)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay before continuing

        Crash(position); // Perform the explosion
    }
    private void Crash(Vector3 center)
    {
        
        if (Vector3.Distance(center, player.transform.position) < boomR)
        {
            player.ChangeHealth(boomDemage);
        }
    }
}
