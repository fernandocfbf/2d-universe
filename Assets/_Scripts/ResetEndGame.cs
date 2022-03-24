using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetEndGame : MonoBehaviour{
    GameManager gm;

    void Start(){
        gm = GameManager.GetInstance(); 
    }

    public void ResetGame(){
        gm.ChangeState(GameManager.GameState.GAME);
    }
}