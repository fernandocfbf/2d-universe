using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager{
    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;
    private static GameManager _instance;
    public enum GameState {MENU, GAME, PAUSE, VICTORY, LOSE};
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
        GameObject Player = GameObject.FindWithTag("Player");
        Player.GetComponent<PlayerController>().capsules = 0;
        lifes = 3;
        points = 0;
        gameState = GameState.MENU;
    }

    public void ChangeState(GameState nextState){
        if (gameState == GameState.LOSE && nextState == GameState.GAME){
            Reset();
        }

        if (nextState == GameState.PAUSE || nextState == GameState.LOSE){
            Time.timeScale = 0;
        } 
        
        else if (gameState == GameState.PAUSE && nextState == GameState.MENU){
            Time.timeScale = 0;
        }

        else Time.timeScale = 1.0f;

        gameState = nextState;
        changeStateDelegate();
    }

    private void Reset(){
        lifes = 3;
        points = 0;
    }
}
