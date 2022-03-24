using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable{
    Animator animator;
    public GameObject tiro;

    private void Start(){
        animator = GetComponent<Animator>();
    }

    private void Update(){
        
    }

    public void Shoot()
    {
        Instantiate(tiro, transform.position, Quaternion.identity);
      //throw new System.NotImplementedException();
    }

    public void TakeDamage(){
        Die();
    }

    public void Die(){
        Destroy(gameObject);
    }

    float angle = 0;

    private void FixedUpdate()
    {
        angle += 0.05f;
        Mathf.Clamp(angle, 0.0f, 1.0f * Mathf.PI);
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);
        Thrust(x, y);
        if (x != 0 || y != 0) animator.SetFloat("velocity", 1.0f);
        else animator.SetFloat("velocity", 0.0f);
    }
}
