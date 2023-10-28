using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected int distance;
    [SerializeField] protected float probability;
    public virtual void Influence()
    {
        Debug.LogWarning("No Influence");
    }
    protected void End()
    {
        ObjectPool.Instance.DestroySkill(this);
        EntityManager.Instance.RemoveSkill(this);
    }
}
