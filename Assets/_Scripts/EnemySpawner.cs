using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start(){
        Build();
    }

    // Update is called once per frame
    void Update(){
        
    }

    void Build(){
        // for(int i = 2; i < 9; i++){
        //     for(int j = 0; j < 4; j++){
                // Vector3 position = new Vector3(-9 + 1.75f * i, 4 - 1.3f * j);
                Vector3 position = new Vector3(-9 + 1.75f * 2, 4 - 1.3f * 0);
                Instantiate(Enemy, position, Quaternion.identity, transform);
        //     }   
        // }
    }
}
