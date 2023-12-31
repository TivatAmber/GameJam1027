using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : BaseEntity
{
    [SerializeField] private float maxCooldown;
    [SerializeField] private float timer;

    [Header("Buff and Magic Setting")]
    [SerializeField] private int maxBuffNumber;
    [SerializeField] private int maxMagicNumber;
    private int buffNumber;
    private int magicNumber;

    [Header("Exp Setting")]
    [SerializeField] private CircleCollider2D expCellector;
    [SerializeField] private float getExpRange;
    [SerializeField] private int maxExp;
    [SerializeField] private int deltaMaxExp;
    [SerializeField] private int exp;
    private int level;

    public Vector3 forward;
    public int AvailableBufferNumber
    {
        get { return maxBuffNumber - buffNumber; }
    }
    public int AvailableMagicNumber
    {
        get { return maxMagicNumber - magicNumber; }
    }
    public int Level
    {
        get { return level; }
    }
    public int Health
    {
        get { return health; }
    }
    public int MaxHealth
    {
        get { return maxHealth; }
    }
    public int Exp
    {
        get { return exp; }
    }
    public int MaxExp
    {
        get { return maxExp; }
    }
    new private void Start()
    {
        base.Start();
        expCellector.radius = getExpRange;
    }
    private void Update()
    {
        ChangeSpeed();
        ChangePosition();
        if (Order.getSkill && timer > maxCooldown) GetSkill();
        if (timer < maxCooldown) timer += Time.deltaTime;
    }
    void ChangePosition()
    {
        transform.position += speed * Time.deltaTime;
    }
    void ChangeSpeed()
    {
        speed = Vector3.zero;
        // Up
        if (Order.upCode)
        {
            speed += Vector3.up;
        }

        // Down
        if (Order.downCode)
        {
            speed += Vector3.down;
        }

        // Left
        if (Order.leftCode)
        {
            speed += Vector3.left;
        }

        // Right
        if (Order.rightCode)
        {
            speed += Vector3.right;
        }

        forward = speed.normalized;
        speed = maxSpeed * forward;
    }
    void GetSkill()
    {
        BaseSkill skill = FindNearestSkill();
        if (skill != null) skill.Influence();
        timer = 0f;
    }
    
    BaseSkill FindNearestSkill()
    {
        float dist = 0f;
        BaseSkill ret = null;
        foreach (BaseSkill skill in EntityManager.Instance.skills)
        {
            float nowDist = ToolFunc.Dist(gameObject.transform.position, skill.gameObject.transform.position);
            if (ret == null || dist > nowDist)
            {
                ret = skill;
                dist = nowDist;
            }
        }
        return ret;
    }
    public void AddExp(int delta)
    {
        exp += delta;
        if (exp >= maxExp)
        {
            exp = 0;
            maxExp += deltaMaxExp;
            LevelManager.Instance.LevelUp();
        }
    }
    public void AddGetExpRange(int delta)
    {
        getExpRange += delta;
        expCellector.radius = getExpRange;
    }
    protected override void Die()
    {
        Application.Quit();
        Debug.Log("End Game");
    }
}
