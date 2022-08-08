using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Joueur_Stats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public HealthBar healthBar;

    public int nbkill = 0;

    public int maxRage = 100;
    public int currentRage = 0;
    public RageBar rageBar;
    public bool inRage = false;
    private GameObject fireRage;

    private float time;
    private float timeDelay;
    public int attaque;

    void Start()
    {
        fireRage = GameObject.Find("FireSwordPS");
        currentRage = 0;
        rageBar.SetMaxRage(maxRage);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        attaque = 20;
        time = 0f;
        timeDelay = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRage == maxRage)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                fireRage.transform.GetChild(0).gameObject.SetActive(true);
                inRage = true;
            }
        }
        if (inRage)
        {
            attaque = 40;
            if (currentRage <= 0)
            {
                fireRage.transform.GetChild(0).gameObject.SetActive(false);
                inRage = false;
                attaque = 20;
            }
            else
            {
                time = time + 1f * Time.deltaTime;
                if (time >= timeDelay)
                {
                    time = 0f;
                    currentRage -= 10;
                }
            }
        }
        healthBar.SetHealth(currentHealth);
        rageBar.SetRage(currentRage);

        if(currentHealth <= 0){
            SceneManager.LoadScene(7);
        }
    }

}
