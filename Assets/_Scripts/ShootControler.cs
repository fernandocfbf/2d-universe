using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControler : MonoBehaviour{
    public ShootControler exp;

    void Start (){
            exp = GetComponent<ShootControler>();
    }

    void Update(){
        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);
        if ( posicaoViewport.x < 0 ||
            posicaoViewport.x > 1 ||
            posicaoViewport.y < 0 ||
            posicaoViewport.y < 0
        ){
            Destroy(exp);
        }
    }
}
