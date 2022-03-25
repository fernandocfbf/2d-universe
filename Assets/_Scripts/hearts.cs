using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class hearts : MonoBehaviour
{
    GameManager gm;
    public float speed = 2.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {    
        gm = GameManager.GetInstance();
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-4.0f,0); //right to left (-speed,0)
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -2*screenBounds.x ){
            Destroy(this.gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            Destroy(gameObject);
            gm.lifes ++;
        }
    }
}
