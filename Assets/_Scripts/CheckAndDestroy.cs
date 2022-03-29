using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAndDestroy : MonoBehaviour{

    GameManager gm;
    private GameManager.GameState previous;
    private GameManager.GameState next;
    
    void Start(){
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += CheckForDestroy;
        next = gm.gameState;
    }

    void DestroyList(GameObject[] list){
        for(int i = 0 ; i < list.Length; i ++){
            Destroy(list[i]);
        }
    }

    void DestroyAll(){
        GameObject[] gameEnemies = GameObject.FindGameObjectsWithTag("enemy");
        GameObject[] gameBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        GameObject[] gameLifes = GameObject.FindGameObjectsWithTag("Life");
        GameObject[] gameCapsules = GameObject.FindGameObjectsWithTag("Capsule");

        DestroyList(gameEnemies);
        DestroyList(gameBullets);
        DestroyList(gameLifes);
        DestroyList(gameCapsules);
    }

    void CheckForDestroy(){

        previous=next; 
        next=gm.gameState;
        
        //reset
        if (previous == GameManager.GameState.LOSE && next == GameManager.GameState.GAME){
            DestroyAll();
        }

        //quit
        if (previous == GameManager.GameState.PAUSE && next == GameManager.GameState.MENU){
            DestroyAll();
        }

        //quit
        if (previous == GameManager.GameState.LOSE && next == GameManager.GameState.MENU){
            DestroyAll();
        }
        if(previous == GameManager.GameState.GAME && next == GameManager.GameState.VICTORY){
            DestroyAll();
        }
    }
}
