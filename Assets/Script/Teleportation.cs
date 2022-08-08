using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Teleportation : MonoBehaviour
{
    private int sceneNumber;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "ProjectSouls")
        {
            sceneNumber = 2;
        }
        if (sceneName == "SimpleNaturePack_Demo")
        {
            sceneNumber = 3;
        }
        if (sceneName == "rpgpp_lt_scene_1.0")
        {
            sceneNumber = 4;
        }
        if (sceneName == "demoScene_free")
        {
            sceneNumber = 5;
        }
        if (sceneName == "Demo4")
        {
            sceneNumber = 6;
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }
}
