using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMagic : MonoBehaviour, IUpGrade
{
    [SerializeField] protected int damage;
    [SerializeField] protected int combo;
    [SerializeField] protected int maxLevel;
    [SerializeField] protected float speed;
    [SerializeField] protected float range;
    [SerializeField] protected float cooldown;
    protected int level;
    protected float timer;
    public int Level { get { return level; } }
    public bool CanUpGrade { get { return maxLevel != level; } }
    protected virtual IEnumerator Fire() { yield break; }
    protected virtual BaseEnemy FindEnemy()
    {
        throw new Exception("Don't have FindEnemy Method");
    }
    public virtual void UpGrade() { }
    public virtual void AddCombo(int delta)
    {
        combo++;
    }
    public virtual void SubCoolTime(int percent)
    {
        combo *= (1 - percent);
    }
}
