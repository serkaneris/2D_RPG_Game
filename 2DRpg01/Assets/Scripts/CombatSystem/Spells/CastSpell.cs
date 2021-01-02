using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    public GameObject spellPrefab;
    //public float minDamage;
    //public float maxDamage;
    public float spellSpeed = 2f;
    public float spellDamage = 10;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject spell = Instantiate(spellPrefab, transform.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 playerPos = transform.position;
            Vector2 direction = (mousePos - playerPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * spellSpeed;
            spell.GetComponent<ISpell>().SpellCasterTag = transform.tag;
            spell.GetComponent<ISpell>().Damage = spellDamage;
        }
    }
}
