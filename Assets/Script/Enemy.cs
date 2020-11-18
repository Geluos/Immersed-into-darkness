using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healthEnemy;

    void Update()
    {
        if (healthEnemy <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        healthEnemy -= damage;
    }
}
