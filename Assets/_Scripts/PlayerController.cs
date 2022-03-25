﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable{
    Animator animator;
    public AudioClip shootSFX;
    private Vector3 currentPosition;
    public GameObject bullet;
    GameManager gm;
    public Transform gun01;
    public float shootDelay = 1.0f;
    private float lastShootTimestamp = 0.0f;

    public void Start(){
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();
    }

    private void Update(){
        if (gm.gameState != GameManager.GameState.GAME) return;
        if(Input.GetAxisRaw("Fire1") != 0) Shoot();
        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME)
            gm.ChangeState(GameManager.GameState.PAUSE);
    }

    public void Shoot(){
        if(Time.time - lastShootTimestamp > shootDelay){
            AudioManager.PlaySFX(shootSFX);
            lastShootTimestamp = Time.time;
            Instantiate(bullet, gun01.position, Quaternion.identity);
        } 
    }

    public void TakeDamage(){
        gm.lifes --;
        if (gm.lifes <= 0) Die();
    }

    public void Die(){
        gm.ChangeState(GameManager.GameState.LOSE);
        //Destroy(gameObject); always on the scene
    }

    void FixedUpdate(){
        if (gm.gameState != GameManager.GameState.GAME) return;
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);
        currentPosition = new Vector3(xInput, yInput, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("enemy")){
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }


    
}
