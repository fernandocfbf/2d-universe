using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : SteerableBehaviour, IShooter, IDamageable{

    public int BossLifes = 250;
    public GameObject tiro;
    Animator animator;
    float angle = 0;
    GameManager gm;

    void Start(){
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();
    }

    public void Shoot(){

        if(BossLifes < 100){
            Instantiate(tiro, new Vector3(transform.position.x-3.0f, transform.position.y+0.40f, transform.position.z), Quaternion.identity);
            Instantiate(tiro, new Vector3(transform.position.x-3.0f, transform.position.y-0.40f, transform.position.z), Quaternion.identity);
        }
        Instantiate(tiro, new Vector3(transform.position.x-1.5f, transform.position.y+0.80f, transform.position.z), Quaternion.identity);
        Instantiate(tiro, new Vector3(transform.position.x-1.5f, transform.position.y-0.80f, transform.position.z), Quaternion.identity);
    }

    public void TakeDamage(){
        BossLifes --;
        if (BossLifes <= 0){
            Die();
        }
    }

    public void Die(){
        CalculatePoints();
        Destroy(gameObject);
        gm.ChangeState(GameManager.GameState.VICTORY);
    }

    private void CalculatePoints(){
        gm.points += 1000;
    }

    void CheckBossPosition(){
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

    private void FixedUpdate(){
        angle += 0.05f;
        Mathf.Clamp(angle, 0.0f, 1.0f * Mathf.PI);
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);
        CheckBossPosition();
        Thrust(x, y+0.11f);
    }
}
