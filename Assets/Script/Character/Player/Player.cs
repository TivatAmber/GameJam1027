using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseEntity
{
    public Vector3 forward;
    private void Update()
    {
        ChangeSpeed();
        ChangePosition();
        if (Order.getSkill) GetSkill();
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
        if (skill != null)
        {
            skill.Influence();
        }
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
}
