using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleContent : MonoBehaviour{
    GameManager gm;
    public float speed = 2.0f;
    public float rotateSpeed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private GameObject Player;

    void Start(){
        gm = GameManager.GetInstance();
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-2.0f,0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update(){
        if(transform.position.x < -2*screenBounds.x ){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            Player = GameObject.FindWithTag("Player");
            Player.GetComponent<PlayerController>().capsules ++;
            Destroy(gameObject);
        }
    }
}
