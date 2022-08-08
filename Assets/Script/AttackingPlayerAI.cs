using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackingPlayerAI : MonoBehaviour
{
    //La référance a l'object a suivre
    private Transform joueur;
    private Joueur_Stats j_stats;
    //L'ennemie qui va suivre l'object
    public NavMeshAgent ennemi;
    /*Paramètre modifiable, la distance pour que l'ennemie attaque, la distance pour qui commence a chaser, la distance
     de perte de vue*/
    public float proximiterAttaque = 2.0f;
    public float distDetection = 10.0f;
    public float perdreDeVue = 50.0f;
    public bool isAttacking;
    //Valeur aidant le code
    private float distance;
    private bool suivre;
    //On créer une nouvelle object du script followAI
    private FollowingAI follow;
    public GameObject projectile;
    private float targetTime = 5.0f;
    private bool projectileActiver = false;
    /*private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && bc.enabled == true){
            Debug.Log(other);
            other.GetComponent<Joueur_Stats>().currentHealth -= 20;
        }

    }*/
    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindWithTag("Player").transform;
        //on dit que notre object est l'object FollowAI deja présent sur notre ennemie
        follow = transform.GetComponent<FollowingAI>();
        //Ne suis pas par default, en appelant la méthode MakeEntityMove de notre object, avec la valeur false pour ne pas suivre
        suivre = false;
        follow.MakeEntityMove(joueur, ennemi, false);
    }

    // Update is called once per frame
    void Update()
    {
        /*Stock la distance entre l'object et l'ennemie, avec la fonction distance de vector3(c'est une ligne quoi) 
        qui prend la position des deux objets*/
        distance = Vector3.Distance(joueur.position, transform.position);

        /*Vérifie si la distance entre l'object et l'ennemmie est dans la zone de detection, si oui, 
        on dit que il doit suivre le joueur*/
        if(distance < distDetection){
            suivre = true;
        }
        /*Vérifie si la distance entre l'object et l'ennemmie est plus grande que la distance max, si oui, 
        on dit que l'object à été perdu de vue, et que l'ennemie peut arrêter de suivre*/
        if(distance> perdreDeVue){
            suivre = false;
        }

        //Si on à dit de suivre l'object (et que les paramètre nécésaire ne sont pas manquant)
        if(suivre == true && joueur != null && ennemi != null){

            //Si il est dans la proximiter d'attaque
            if(distance < proximiterAttaque){
                if (gameObject.name == "GolemPrefab")
                {
                    targetTime -= Time.deltaTime;
                    isAttacking = true;
                    //il devra arrèter suivre
                    suivre = false;
                    follow.MakeEntityMove(joueur, ennemi, false);
                    if (targetTime <= 1.0f && projectileActiver == false)
                    {
                        gameObject.GetComponent<Animator>().SetTrigger("Attack");
                        projectileActiver = true;
                    }
                    if (targetTime <= 0.0f)
                    {
                        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
                        Instantiate(projectile, pos, Quaternion.identity);
                        targetTime = 5.0f;
                        projectileActiver = false;
                    }
                }
                else
                {
                    isAttacking = true;
                    //il devra arrèter suivre
                    suivre = false;
                    follow.MakeEntityMove(joueur, ennemi, false);
                    gameObject.GetComponent<Animator>().SetTrigger("Attack");
                }
            }
            else{
                isAttacking = false;
                //On appelle la fonction de l'object follow en mode true, donc il va se mettre a suivre
                follow.MakeEntityMove(joueur, ennemi, true);
            }
        }
        //sinon on ne doit pas suivre, on arrete le movement
        else{
            follow.MakeEntityMove(joueur, ennemi, false);
        }
    }
}
