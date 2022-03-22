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
        Debug.Log("Here!");
        Debug.Log(gm.gameState);
        if(gm.gameState == GameManager.GameState.GAME){
            Vector3 position = new Vector3(0, 0, 0);
            Instantiate(Player, position, Quaternion.identity, transform);
        }
    }
}
