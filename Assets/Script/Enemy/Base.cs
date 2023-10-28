using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    [SerializeField] float attackCooldown;
    [SerializeField] int maxHealth;
    [SerializeField] int damage;
    int health = 0;
    float timer = 0f;
    Vector3 speed = Vector3.zero;
    protected void  Start()
    {
        health = maxHealth;
        
    }
    public void ChangeHealth(int delta)
    {
        health -= delta;
        if (health < 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
