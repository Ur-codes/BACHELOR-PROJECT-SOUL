using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageGift : MonoBehaviour
{
    private GameObject rageEffect;
    private GameObject player;
    void Start()
    {
        rageEffect = GameObject.FindWithTag("Rage");
        player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            StartCoroutine(delay());
            player.GetComponent<Joueur_Stats>().currentRage += 10;
        }
    }
    IEnumerator delay()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        rageEffect.transform.GetChild(0).gameObject.SetActive(true);
        rageEffect.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        rageEffect.transform.GetChild(0).gameObject.SetActive(false);
        rageEffect.transform.GetChild(1).gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
