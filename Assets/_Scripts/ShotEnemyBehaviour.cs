using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShotEnemyBehaviour : SteerableBehaviour
{

  private Vector3 direction;

  private void OnTriggerEnter2D(Collider2D collision)
  {
      if (collision.CompareTag("enemy") || collision.CompareTag("EnemyBullet")) return;

      if (collision.CompareTag("Player Bullet")){
        Destroy(gameObject);
      }
      IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
      if (!(damageable is null))
      {
          damageable.TakeDamage();
      }
      Destroy(gameObject);
      
  }

  void Start()
  {
    if(GameObject.FindWithTag("Player") != null){
    Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
    direction = (posPlayer - transform.position).normalized;  
    }
     
  }

  void Update()
  {
    
    Thrust(direction.x, direction.y);
  }

  private void OnBecameInvisible()
  {
      gameObject.SetActive(false);
  }

}