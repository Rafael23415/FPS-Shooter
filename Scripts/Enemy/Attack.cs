using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] float attackRange = 2f;
    [SerializeField] float attackCooldown = 0.5f;

    [SerializeField] Animator animator;
    [SerializeField] PlayerHealth playerHealth;

    private Transform player;
    private bool isAttacking;

    private void Start()
    {
        player = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange && !isAttacking)
            StartCoroutine(AttackPlayer());
    }

    private IEnumerator AttackPlayer()
    {
        isAttacking = true;
        animator.SetBool("Attack", true);
        GetComponent<EnemyAI>().enabled = false;
        playerHealth.DamagePlayer(damage);
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
        animator.SetBool("Attack", false);
        GetComponent<EnemyAI>().enabled = true;
        Debug.Log("Attacking");
    }

    
}