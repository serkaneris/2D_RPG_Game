using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpellAI : MonoBehaviour
{
    
    public Transform target;
    public Transform targetChecker;
    public float targetCheckerRadius = 2f;
    public LayerMask whatIsTargetLayer;
    public bool IsTargetInRange;
    public bool IsTargetInRangeLast;

    public GameObject spellPrefab;
    public float spellSpeed = 2f;
    public float spellDamage = 10;
    public float spellCooldown = 2;

    private void Start()
    {
       // StartCoroutine(CastSpellToPlayer());
    }

    private void Update()
    {
        IsTargetInRange = Physics2D.OverlapCircle(targetChecker.position, targetCheckerRadius, whatIsTargetLayer);
        if(IsTargetInRange && !IsTargetInRangeLast)
        {
            StartCoroutine(CastSpellToPlayer());
            IsTargetInRangeLast = IsTargetInRange;
        }
        else
            IsTargetInRangeLast = IsTargetInRange;

    }


    IEnumerator CastSpellToPlayer()
    {
        yield return new WaitForSeconds(spellCooldown); 
        if(target!=null && IsTargetInRange)
        {
            GameObject spell = Instantiate(spellPrefab, transform.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 attackerPos = transform.position;
            Vector2 targetPos = target.position;
            Vector2 direction = (targetPos - attackerPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * spellSpeed;
            spell.GetComponent<ISpell>().SpellCasterTag = transform.tag;
            spell.GetComponent<ISpell>().TargetTag = "Player";
            spell.GetComponent<ISpell>().Damage = spellDamage;
            StartCoroutine(CastSpellToPlayer());
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetChecker.position, targetCheckerRadius);
    }
}
