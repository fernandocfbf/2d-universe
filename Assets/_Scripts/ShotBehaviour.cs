using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : SteerableBehaviour{
    void Start(){
        
    }

    void Update(){
        Thrust(1, 0);
        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);
        if ( posicaoViewport.x < 0 ||
            posicaoViewport.x > 1 ||
            posicaoViewport.y < 0 ||
            posicaoViewport.y > 1
        ){
            Debug.Log("HERE");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player") || collision.CompareTag("Player Bullet")){
            return;
        } 
        IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if(!(damageable is null)){
            damageable.TakeDamage();
        }
        Destroy(gameObject);
    }
}
