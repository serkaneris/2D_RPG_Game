using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    public GameObject spellPrefab;
    public float spellSpeed = 2f;
    public float spellDamage = 10;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject spell = Instantiate(spellPrefab, transform.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 attackerPos = transform.position;
            Vector2 direction = (mousePos - attackerPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * spellSpeed;
            spell.GetComponent<ISpell>().SpellCasterTag = transform.tag;
            spell.GetComponent<ISpell>().TargetTag = "Enemy";
            spell.GetComponent<ISpell>().Damage = spellDamage;
        }
    }
}
