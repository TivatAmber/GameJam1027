using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int health;
    private void Start()
    {
        health = maxHealth;
    }
    public void ChangeHealth(int delta)
    {
        health -= delta;
        if (health < 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
