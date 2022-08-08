using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealGift : MonoBehaviour
{
    private GameObject healEffect;
    private GameObject player;
    void Start()
    {
        healEffect = GameObject.FindWithTag("Heal");
        player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SwordPolyart")
        {
            StartCoroutine(delay());
            player.GetComponent<Joueur_Stats>().currentHealth += 30;
        }
    }
    IEnumerator delay()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        healEffect.transform.GetChild(0).gameObject.SetActive(true);
        healEffect.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        healEffect.transform.GetChild(0).gameObject.SetActive(false);
        healEffect.transform.GetChild(1).gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
