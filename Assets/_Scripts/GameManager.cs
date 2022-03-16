using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager{
    private static GameManager _instance;
    public enum GameState {MENU, GAME, PAUSE, ENDGAME};
    public GameState gameState {get; private set;}
    public int lifes;
    public int points;

    public static GameManager GetInstance(){
        if (_instance == null){
            _instance = new GameManager();
        }
        return _instance;
    }

    private GameManager(){
        lifes = 3;
        points = 0;
        gameState = GameState.MENU;
    }

    public void ChangeState(GameState nextState){
        if(gameState == GameState.ENDGAME && nextState == GameState.GAME) Reset();
        gameState = nextState;
    }

    private void Reset(){
        lifes = 3;
        points = 0;
    }
}
