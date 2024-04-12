using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Animator animator;
    public GameObject attackPoint;
    public float attackRange = .5f;
    public LayerMask enemyLayers;
    public int damage = 10;

    public float attackRate = 1f;
    float nextAttackTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                attack();
                nextAttackTime = Time.time + 1f / attackRate; 
            }
        }
        
        
    }

    void attack()
    {
        // Play an attack animation
        animator.SetTrigger("Attack");

        // Detect enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.transform.position, attackRange, enemyLayers);

        // Damage them
        foreach(Collider enemy in hitEnemies) {
            Debug.Log("We hit " + enemy.name);
        }

        // enemy.takeDamage(damage);
    }
}
