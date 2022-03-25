using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//fonte: https://pressstart.vip/tutorials/2018/09/25/58/spawning-obstacles.html
public class deployAsteroids : MonoBehaviour
{   
    public GameObject asteroidPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    GameManager gm;
    
    // Start is called before the first frame update
    void Start()
    {   
        gm = GameManager.GetInstance();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }
    
    private void spawnEnemy(){
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator asteroidWave(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            if (gm.gameState == GameManager.GameState.GAME){
                spawnEnemy();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
