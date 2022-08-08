using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionDetection : MonoBehaviour
{
    private GameObject player;
    public WeaponController wc;
    public float KnockbackForce = 250;
    public GameObject Portal;
    public float tempsEntreDegat;
    private int chance;
    public GameObject Ame;
    public GameObject Cadeaux;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "ProjectSouls" && player.GetComponent<Joueur_Stats>().nbkill >= 15)
        {
            Portal.SetActive(true);
        }
        if (sceneName == "SimpleNaturePack_Demo" && player.GetComponent<Joueur_Stats>().nbkill >= 15)
        {
            Portal.SetActive(true);
        }
        if (sceneName == "rpgpp_lt_scene_1.0" && player.GetComponent<Joueur_Stats>().nbkill >= 20)
        {
            Portal.SetActive(true);
        }
        if (sceneName == "demoScene_free" && player.GetComponent<Joueur_Stats>().nbkill >= 25)
        {
            Portal.SetActive(true);
        }
        if (sceneName == "Demo4" && player.GetComponent<Joueur_Stats>().nbkill >= 1)
        {
            Portal.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && wc.isAttacking)
        {
            Debug.Log(other.name);
            other.GetComponent<Animator>().SetTrigger("GetHit");
            other.GetComponent<Enemy_stats>().currentHealth -= transform.GetComponentInParent<Joueur_Stats>().attaque;
            new WaitForSeconds(tempsEntreDegat);
            //other.transform.position += transform.forward * Time.deltaTime * KnockbackForce;
            chance = Random.Range(1, 21);
            if (chance == 1)
            {
                Vector3 pos = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z);
                Instantiate(Ame, pos, Quaternion.identity);
            }
            if (chance == 2)
            {
                Vector3 pos = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z);
                Instantiate(Cadeaux, pos, Quaternion.identity);
            }

        }
    }
}
