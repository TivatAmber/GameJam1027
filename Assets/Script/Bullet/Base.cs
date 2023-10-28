using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{
    protected Vector3 originPosition = Vector3.zero;
    protected Vector3 speed = Vector3.zero;
    protected int damage;
    protected float range;
    public virtual void setBullet(Vector3 speed, Vector3 originPosition, int damage, float range)
    {
        this.range = range;
        transform.position = this.originPosition = originPosition;
        this.speed = speed;
        this.damage = damage;
    }
    public virtual void setBullet(Vector3 originPosition, int damage, float range)
    {
        this.range = range;
        transform.position = this.originPosition = originPosition;
        this.damage = damage;
    }
    public virtual void setBullet(Vector3 originPosition, int damage)
    {
        transform.position = this.originPosition = originPosition;
        this.damage = damage;
    }
    public virtual void setBullet(int damage, float range)
    {
        this.damage = damage;
        this.range = range;
    }
    public virtual void setBullet(int damage)
    {
        this.damage = damage;
    }
}
