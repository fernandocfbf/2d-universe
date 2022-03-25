using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable{
    Animator animator;
    public GameObject tiro;
    GameManager gm;
    float angle = 0;
    public int enemyType;

    private void Start(){
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();
    }

    private void Update(){
        
    }

    public void Shoot()
    {
        Instantiate(tiro, transform.position, Quaternion.identity);
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

    private void EnableAnimation(float x, float y){
        /*if (x != 0 || y != 0)*/ animator.SetFloat("velocity", 1.0f);
        //else animator.SetFloat("velocity", 0.0f);
    }

    private void FixedUpdate(){
        if (gm.gameState == GameManager.GameState.GAME){
            float x = 0.0f;
            float y = 0.0f;
            if (enemyType == 0){
                angle += 0.3f;
                Mathf.Clamp(angle, 0.0f, 1.0f * Mathf.PI);
                x = -1+ Mathf.Sin(angle);
                y = Mathf.Sin(angle);
            }
            else if(enemyType == 1){
                Debug.Log(transform.position.x);
                //while in the walk zone
                if(transform.position.x > 5){
                    x = -1;
                    y = 0;
                }
                else{
                    y=0.01f;
                }
            }  
            Thrust(x, y);
            EnableAnimation(x, y);
        }
    }
}
