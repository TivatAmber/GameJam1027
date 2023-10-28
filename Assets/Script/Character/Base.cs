using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEntity : MonoBehaviour
{
    [SerializeField] protected float maxSpeed;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int health = 0;
    protected Vector3 speed = Vector3.zero;
    protected void Start()
    {
        health = maxHealth;
    }
    protected virtual void Die()
    {
        throw new Exception("Not Die");
    }
    public void ChangeHealth(int delta)
    {
        health -= delta;
        if (health <= 0)
        {
            Die();
        }
    }
}
