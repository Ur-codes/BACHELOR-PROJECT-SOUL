using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Attack_Enemy : MonoBehaviour
{
    public Attack_Enemy ec;
    public float tempsEntreDegat;
    public AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && ec.hitting)
        {
            Debug.Log(other.name);
            audio.PlayOneShot(audio.clip);
            other.GetComponent<Joueur_Stats>().currentHealth -= transform.GetComponentInParent<Enemy_stats>().attaque;
            new WaitForSeconds(tempsEntreDegat);
        }
    }
}