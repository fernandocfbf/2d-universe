using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wayController : SteerableBehaviour, IShooter, IDamageable
{
 public GameObject tiro;
    public void Shoot()
  {
      Instantiate(tiro, transform.position  + new Vector3(0.8f, 0.0f, 0.0f), Quaternion.identity);
  }

    public void TakeDamage()
   {
       Die();
   }

    public void Die()
    {
        Destroy(gameObject);
    }

}