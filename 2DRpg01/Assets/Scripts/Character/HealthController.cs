using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController
    : MonoBehaviour
{
    public float health;
    public float maxHealth;
    void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(float damage)
    {
        health -= damage;

        print(gameObject.tag + " deal dmg: " + damage + " healt: " + health);

        CheckDeath();
    }

    private void CheckOverHeal()
    {
        if (health > maxHealth)
            health = maxHealth;
    }

    private void CheckDeath()
    {
        if(health <=0)
            Destroy(gameObject);
    }
}
