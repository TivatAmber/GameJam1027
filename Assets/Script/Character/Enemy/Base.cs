using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BaseEnemy : BaseEntity
{
    private TimeManager timeManager;
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
        FallenThings();
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
    protected void FallenThings()
    {
        timeManager = GetComponent<TimeManager>();
        float globalProbability = FallenProbability(timeManager.globalTime / 60);
        float randomValue1 = UnityEngine.Random.value;
        float randomValue2 = UnityEngine.Random.value;
        float bigBallProbility = 1 - 1.8f * timeManager.globalTime / 60;
        if (randomValue1 < globalProbability)
        {
            ObjectPool objectPool = FindObjectOfType<ObjectPool>();
            ExperienceBall newBall = objectPool.GetExperienceBall();
            
            if (objectPool != null)
            {
                newBall.transform.position = transform.position;// 设置生成位置
                if (randomValue2 < bigBallProbility)
                {
                    newBall.maxExperience = 5;
                }
                // 在这里可以设置经验球的位置、旋转等属性
                newBall.gameObject.SetActive(true);
            }
        }
    }
    protected float FallenProbability(float timeMinite)
    {
        return 1 / 3 * timeMinite;
    }
}
