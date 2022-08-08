using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    public bool isAttacking = false;
    public BoxCollider bc;
    public AudioSource audio;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {
                SwordAttack();
            }
        } 
    }

    public void SwordAttack()
    {
        isAttacking = true;
        CanAttack = false;
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Attack");
        audio.PlayOneShot(audio.clip);
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown / 2);
        isAttacking = false;
        CanAttack = true;
    }
}
