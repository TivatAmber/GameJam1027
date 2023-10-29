using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public abstract class BaseEnemy : BaseEntity
{
    private TimeManager timeManager;
    [SerializeField] protected float attackCooldown;
    [SerializeField] protected int damage;
    [SerializeField] protected int additionalHealth;
    protected float timer = 0f;
    private void Awake()
    {
        timeManager = TimeManager.Instance;
    }
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
        FallenSkills();
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
    private void FallenSkills()
    {
        float probability = FallenSkill(timeManager.globalTime / 60f);
        probability = Mathf.Max(0.01f, probability);
        if (UnityEngine.Random.value < probability)
        {
            float now = UnityEngine.Random.value;
            BaseSkill obj = null;
            if (now < 0.5f)
            {
                obj = ObjectPool.Instance.GetDashSkill();
            } 
            else if (now < 0.6f)
            {
                obj = ObjectPool.Instance.GetHugeSoulSpearSkill();
            }
            else if (now < 0.75f)
            {
                obj = ObjectPool.Instance.GetHealSkill();
            }
            if (obj != null)
            {
                EntityManager.Instance.skills.Add(obj);
                obj.transform.position = gameObject.transform.position;
            }
        }
    }
    protected float FallenProbability(float timeMinite)
    {
        return 1.0f / 3.0f * timeMinite;
    }
    protected float FallenSkill(float timeMinite)
    {
        return 1.0f / (20 + 20 * timeMinite);
    }
}
