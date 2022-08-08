using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    public GameObject projectile;
    void Start()
    {
        StartCoroutine(AttackDelay());
    }

    IEnumerator AttackDelay()
    {
        while (true)
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //}
            yield return new WaitForSeconds(1);
            Animator anim = GetComponent<Animator>();
            anim.SetTrigger("Attack");
            GameObject fireball = Instantiate(projectile, transform);
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 10;
            yield return new WaitForSeconds(4);
        }
    }
}
