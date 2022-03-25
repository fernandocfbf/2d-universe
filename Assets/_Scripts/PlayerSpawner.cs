using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour{
    GameManager gm;
    public GameObject Player;

    void Start(){
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += BuildPlayer;
        BuildPlayer(); //build first player instance
    }

    void BuildPlayer(){
        if(gm.gameState == GameManager.GameState.GAME){
            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
