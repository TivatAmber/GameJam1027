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
}
