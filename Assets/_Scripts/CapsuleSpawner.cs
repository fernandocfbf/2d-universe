using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleSpawner : MonoBehaviour{
    public GameObject capsulePrefab;
    public float tryTime = 3.0f;
    private Vector2 screenBounds;
    GameManager gm;
    
    void Start(){   
        gm = GameManager.GetInstance();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(CapsuleWave());
    }
    
    private void SpawnCapsule(){
        GameObject a = Instantiate(capsulePrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x, Random.Range(-screenBounds.y, screenBounds.y));
    }

    private int TryLucky(){
        int randomNumber = Random.Range(0, 2); //10% of chance
        Debug.Log(randomNumber); 
        if (randomNumber == 1) return 1;
        return 0;
    }

    IEnumerator CapsuleWave(){
        while(true){
            yield return new WaitForSeconds(tryTime);
            if (gm.gameState == GameManager.GameState.GAME){
                if(TryLucky() == 1) SpawnCapsule();
            }
        }
    }
}
