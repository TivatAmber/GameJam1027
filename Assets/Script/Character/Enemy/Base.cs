using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BaseEnemy : BaseEntity
{
    [SerializeField] protected float attackCooldown;
    [SerializeField] protected int damage;
    protected float timer = 0f;

    protected virtual void Attack()
    {
        throw new Exception("Can't Attack");
    }
    protected virtual void Move()
    {
        throw new Exception("Can't Move");
    }
}
