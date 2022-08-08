using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MonsterSpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public int enemyCount;
    public int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "ProjectSouls")
        {
            enemyCount = 15;
        }
        if (sceneName == "SimpleNaturePack_Demo")
        {
            enemyCount = 15;
        }
        if (sceneName == "rpgpp_lt_scene_1.0")
        {
            enemyCount = 10;
        }
        if (sceneName == "demoScene_free")
        {
            enemyCount = 24;
        }
        if (sceneName == "Demo4")
        {
            enemyCount = 1;
        }
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (i < enemyCount)
        {
            Instantiate(theEnemy, gameObject.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            i += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
