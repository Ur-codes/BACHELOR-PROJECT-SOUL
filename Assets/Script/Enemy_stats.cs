using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_stats : MonoBehaviour
{
    public int currentHealth;
    private GameObject player;
    public int attaque;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if(currentHealth <= 0){
            player.GetComponent<Joueur_Stats>().nbkill += 1;
            Object.Destroy(this.gameObject);
        }
    }
}
