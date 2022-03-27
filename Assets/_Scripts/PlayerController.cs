using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerController : SteerableBehaviour, IShooter, IDamageable{
    Animator animator;
    public AudioClip shootSFX;
    private Vector3 currentPosition;
    public GameObject bullet;
    GameManager gm;
    public Transform gun01;
    public Transform gun02;
    public Transform gun03;
    public float shootDelay = 1.0f;
    private float lastShootTimestamp = 0.0f;
    public int capsules = 0;

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
        if(Time.time - lastShootTimestamp > shootDelay*GetCandecy(capsules)){
            AudioManager.PlaySFX(shootSFX);
            lastShootTimestamp = Time.time;

            if(capsules == 0)
                Instantiate(bullet, gun01.position, Quaternion.identity);
            else {
                Instantiate(bullet, gun02.position, Quaternion.identity);
                Instantiate(bullet, gun03.position, Quaternion.identity);
            }
        } 
    }

    private double GetCandecy(int capsules){
        int remaining = capsules - 1;
        if(remaining > 0){
            return Math.Pow(0.9f, remaining);
        }
        return 1.0d;
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
        CheckPlayerPosition();
        Thrust(xInput, yInput);
        
    }

    void CheckPlayerPosition(){
        float screen_size_y=5.0f;
        float screen_size_x=7.0f;
        if (transform.position.y <= -screen_size_y)
            transform.position = new Vector3(transform.position.x, -screen_size_y, transform.position.z);
        else if (transform.position.y >=screen_size_y)
            transform.position = new Vector3(transform.position.x, screen_size_y - 0.3f, transform.position.z);

        if (transform.position.x <= -screen_size_x)
            transform.position = new Vector3(-screen_size_x, transform.position.y, transform.position.z);
        else if (transform.position.x >= screen_size_x)
            transform.position = new Vector3(screen_size_x, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("enemy")){
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }


    
}
