using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public Vector3 attackRange;
    public LayerMask enemyLayers;
    public int attackDamage = 10;

    public float attackRate = 2f;
    float nextAttackTime = 0f;
    
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        Debug.Log("HIYAH");
        animator.SetTrigger("Attack");

        Collider[] hitenemies = Physics.OverlapBox(attackPoint.position, attackRange / 2, attackPoint.localRotation, enemyLayers);
        foreach (Collider enemy in hitenemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected() 
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireCube(attackPoint.position, attackRange);
    }
}
