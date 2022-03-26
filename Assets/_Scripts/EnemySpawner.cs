using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{
    public GameObject asteroidPrefab;
    public GameObject drone1Prefab;
    public GameObject drone2Prefab;
    public float respawnTime = 1.0f;
    private float lastLevelTime = 0.0f;
    private Vector2 screenBounds;
    private GameObject randomPrefab;
    int randomMoviment;
    GameManager gm;

    void Start(){
        gm = GameManager.GetInstance();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        GameManager.changeStateDelegate += CleanAndStart;
        CleanAndStart();
    }

    private void SpawnEnemy(){
        randomPrefab = GenerateRandomEnemy();
        GameObject a = Instantiate(randomPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x, Random.Range(-screenBounds.y, screenBounds.y));
    }

    void CleanAndStart(){
        if (gm.gameState == GameManager.GameState.GAME){
            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }
            StartCoroutine(GenerateWaves());
        }
    }

    private GameObject GenerateRandomEnemy(){
        int randomNumber = Random.Range(0, 3);
        if (randomNumber == 0) return asteroidPrefab;
        else if(randomNumber == 1) return drone1Prefab;
        return drone2Prefab;
    }

    private int GenerateRandomMoviment(){
        int randomMoviment = Random.Range(0, 3);
        return randomMoviment;
    }

    IEnumerator GenerateWaves(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            if (gm.gameState == GameManager.GameState.GAME){
                if (Time.time - lastLevelTime >= respawnTime &&
                    respawnTime >= 0.5f){
                    lastLevelTime = Time.time;
                    respawnTime *= 0.99f;
                }
                SpawnEnemy();
            }
        }
    }
}
