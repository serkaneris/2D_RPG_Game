using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceball : MonoBehaviour,ISpell
{
    public string SpellCasterTag { get; set; }
    public string TargetTag { get; set; }
    public float Damage { get; set ; }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(SpellCasterTag + " ice attack to " + collision.tag);
        if (collision.tag == TargetTag)
        {
            var enemyHealt = collision.GetComponent<HealthController>();
            enemyHealt.DealDamage(Damage);
        }

        if (collision.tag != SpellCasterTag)
        {
            Destroy(gameObject);
        }
    }
}
