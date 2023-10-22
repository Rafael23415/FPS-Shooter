using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaged : MonoBehaviour, IDamageable
{
    public float health;

    public GameObject gunHitEffect;

    public void TakeDamage(float damage)
    {
        health -= damage;
        Instantiate(gunHitEffect, transform.position, Quaternion.identity);
        if (health <= 0)
            Destroy(gameObject);
    }
}
