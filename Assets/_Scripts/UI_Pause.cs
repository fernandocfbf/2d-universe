using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pause : MonoBehaviour{
    GameManager gm;
    
    private void OnEnable(){
      gm = GameManager.GetInstance();
    }

    public void Resume(){
        gm.ChangeState(GameManager.GameState.GAME);
    }

    public void Quit(){
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
