using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShotBossBehaviour : SteerableBehaviour
{

  private Vector3 direction;
  float angle = 0;

  private void OnTriggerEnter2D(Collider2D collision)
  {
      if (collision.CompareTag("enemy")) return;

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
    angle += 0.01f;
    Mathf.Clamp(angle, 0.0f, 1.0f * Mathf.PI);
    float x = Mathf.Sin(angle);
    float y = Mathf.Cos(angle);
    Thrust(direction.x + x, direction.y + y);
  }

  private void OnBecameInvisible()
  {
      gameObject.SetActive(false);
  }

}