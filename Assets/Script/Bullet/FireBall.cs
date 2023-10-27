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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
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
                ObjectPool.Instance.DestoryFireBall(this);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += speed;
    }
}