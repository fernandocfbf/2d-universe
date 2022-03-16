using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable{
    Animator animator;
    public AudioClip shootSFX;
    private Vector3 currentPosition;
    public GameObject bullet;
    public Transform gun01;
    public float shootDelay = 1.0f;
    private float lastShootTimestamp = 0.0f;
    private int lifes;

    public void Start(){
        lifes = 10;
        animator = GetComponent<Animator>();
    }

    private void Update(){
        if(Input.GetAxisRaw("Fire1") != 0) Shoot();
    }

    public void Shoot(){
        if(Time.time - lastShootTimestamp > shootDelay){
            AudioManager.PlaySFX(shootSFX);
            lastShootTimestamp = Time.time;
            Instantiate(bullet, gun01.position, Quaternion.identity);
        } 
    }

    public void TakeDamage(){
        lifes --;
        if (lifes <= 0) Die();
    }

    public void Die(){
        Destroy(gameObject);
    }

    void FixedUpdate(){
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
