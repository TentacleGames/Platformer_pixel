using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAttack : MonoBehaviour
{
    public int damage = 1;
    public string collisionTag;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(collisionTag)){
            int k = UnityEngine.Random.Range(10,100);
            HealthSystem hpSystem = col.gameObject.GetComponent<HealthSystem>();
            if (hpSystem != null)
                hpSystem.TakeHit(damage);

        }
    
    }


}
