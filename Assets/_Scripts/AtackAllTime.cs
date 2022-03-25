using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackAllTime : State{
    SteerableBehaviour steerable;
    IShooter shooter;
    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;

    public override void Awake(){
        base.Awake();
        steerable = GetComponent<SteerableBehaviour>();
        shooter = steerable as IShooter;
        if(shooter == null)
       {
           throw new MissingComponentException("Este GameObject não implementa IShooter");
       }
    }

    public override void Update(){
       if (Time.time - _lastShootTimestamp < shootDelay) return;
       _lastShootTimestamp = Time.time;
       shooter.Shoot();
   }
}
