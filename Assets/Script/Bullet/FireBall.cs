using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireBall : MonoBehaviour
{
    private Vector3 speed = Vector3.zero;
    private int damage;
    public Vector3 Speed
    {
        set
        {
            speed = value;
        }
    }
    public int Damage
    {
        set
        {
            damage = value;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject target = collision.collider.gameObject;
        TestCollsion(target);
    }
    void TestCollsion(GameObject target)
    {
        if (target != null && target.tag == "Enemy")
        {
            Health targetHealth = target.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.ChangeHealth(damage);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += speed;
    }
}