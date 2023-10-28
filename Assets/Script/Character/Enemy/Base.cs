using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BaseEnemy : BaseEntity
{
    [SerializeField] protected float attackCooldown;
    [SerializeField] protected int damage;
    [SerializeField] protected float timer = 0f;
    protected virtual void Move()
    {
        throw new Exception("Can't Move");
    }
}
