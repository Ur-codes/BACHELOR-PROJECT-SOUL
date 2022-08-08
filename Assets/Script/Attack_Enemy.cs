using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Enemy : MonoBehaviour
{
    private bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    public bool hitting = false;
    public BoxCollider bc;
    
    private AttackingPlayerAI attack;

    void Start(){
        attack = transform.GetComponentInParent<AttackingPlayerAI>();
    }

    void Update()
    {
        if (attack.isAttacking == true)
        {
            if (CanAttack)
            {
                Attack();
            }
        } 
    }

    public void Attack()
    {
        hitting = true;
        CanAttack = false;
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown / 2);
        bc.enabled = false;
        yield return new WaitForSeconds(AttackCooldown / 2);
        bc.enabled = true;
        hitting = false;
        CanAttack = true;
    }
}
