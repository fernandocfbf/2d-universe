using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{
    public GameObject Enemy;
    GameManager gm;

    void Start(){
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Build;
        Build();
    }

    void Build(){
        if (gm.gameState == GameManager.GameState.GAME){
            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }
            Vector3 position = new Vector3(-9 + 1.75f * 2, 4 - 1.3f * 0);
            Instantiate(Enemy, position, Quaternion.identity, transform);
            /*for(int i = 2; i < 9; i++){
                for(int j = 0; j < 4; j++){
                    Vector3 position = new Vector3(-9 + 1.75f * i, 4 - 1.3f * j);
                    Instantiate(Enemy, position, Quaternion.identity, transform);
                }   
            }*/
        }
    }
}
