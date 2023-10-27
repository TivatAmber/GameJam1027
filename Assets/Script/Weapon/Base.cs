using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMagic : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected float speed;
    [SerializeField] protected float range;
    [SerializeField] protected float cooldown;
    protected int level;
    protected float timer;
    protected virtual void Fire() { }
    protected virtual void Upgrade() { }
    protected virtual GameObject FindEnemy() { 
        throw new Exception("Don't have FindEnemy Method");
    }
    public virtual void Update()
    {
        
    }
}
