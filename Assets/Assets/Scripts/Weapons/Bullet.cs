using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float damage = 25.0f;
    
    public GameObject bulletHole;

    private void Start()
    {
        damage = 25.0f;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyManager enemyManager = other.gameObject.GetComponent<EnemyManager>();
            
            if (enemyManager != null)
            {
                enemyManager.Hit(damage);
                Destroy(gameObject);
            }
        }
        else
        { 
            Destroy(gameObject);
            /*
            GameObject hole = Instantiate(bulletHole, transform.position, transform.rotation);
            Destroy(hole, 5f);
            */
        }
    }
}
 