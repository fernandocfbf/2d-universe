using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable{
    Animator animator;
    GameManager gm;
    float angle = 0;

    private void Start(){
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();
    }

    private void Update(){
        
    }

    public void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(){
        Die();
    }

    public void Die(){
        CalculatePoints();
        Destroy(gameObject);
    }

    private void CalculatePoints(){
        gm.points ++;
    }

    private void FixedUpdate(){
        angle += 0.05f;
        Mathf.Clamp(angle, 0.0f, 1.0f * Mathf.PI);
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);
        Thrust(x, y);
        if (x != 0 || y != 0) animator.SetFloat("velocity", 1.0f);
        else animator.SetFloat("velocity", 0.0f);
    }
}
