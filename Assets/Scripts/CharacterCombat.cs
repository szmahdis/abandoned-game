using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{

    public float attackSpeed = 1.0f;

    private float attackCooldown = 0.0f;

    public float attackDelay = .1f;

    public event System.Action OnAttack;

    CharacterStats myStats;

    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        //Debug.Log(myStats.damage.GetValue());

        //Debug.Log("player stats:");
        //Debug.Log(targetStats.ToString());

        //Debug.Log("________");
        //targetStats.TakeDamage(myStats.damage.GetValue());
        
        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));

            if (OnAttack != null)
                OnAttack();

            //targetStats

            attackCooldown = 1f / attackSpeed;
        }
        

    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(myStats.damage.GetValue());
    }
}
