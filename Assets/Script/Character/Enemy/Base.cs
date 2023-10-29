using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BaseEnemy : BaseEntity
{
    [SerializeField] protected float attackCooldown;
    [SerializeField] protected int damage;
    [SerializeField] protected int additionalHealth;
    protected float timer = 0f;
    new private void Start()
    {
        base.Start();
    }
    protected virtual void Move()
    {
        throw new Exception("Can't Move");
    }
    protected override void Die()
    {
        ObjectPool.Instance.DestroyEnemy(this);
        EntityManager.Instance.RemoveEnemy(this);
    }
    public void AddMaxHealth(int delta)
    {
        additionalHealth += delta;
    }
    public void Init(Vector3 positon)
    {
        health = maxHealth + additionalHealth;
        timer = attackCooldown;
        transform.position = positon;
    }
} 
