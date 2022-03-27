using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//fonte: https://pressstart.vip/tutorials/2018/09/25/58/spawning-obstacles.html
public class deployHearts : MonoBehaviour
{   
    public GameObject heartPrefab;
    public float respawnTime = 2.0f;
    private Vector2 screenBounds;
    
    GameManager gm;
    
    // Start is called before the first frame update
    void Start()
    {   
       gm = GameManager.GetInstance();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(heartWave());
    }
    
    private void spawnHeart(){
        GameObject a = Instantiate(heartPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x, Random.Range(-screenBounds.y, screenBounds.y));
    }
    private int TryLucky(){
        int randomNumber = Random.Range(0, 2); //10% of chance
        Debug.Log(randomNumber); 
        if (randomNumber == 1) return 1;
        return 0;
    }

    IEnumerator heartWave(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            if (gm.gameState == GameManager.GameState.GAME){
                if(TryLucky() == 1)spawnHeart();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
