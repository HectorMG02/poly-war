using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{

    public GameObject player;
    public Animator enemyAnimator;
    public float damage = 20f;
    public float health = 100f;
    
    public GameManager gameManager;
    
    public GameObject healthItem;
    public GameObject powerUPItem;
    public int itemProb = 3;
    
    public bool isDeath = false;
    public bool isAttacking = false;

    public AudioSource shootController;
    public AudioClip shootClip;
    
    public AudioSource hitController;
    public AudioClip hitClip;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
 
    void Update()
    {
        if (!isDeath)
        {
            GetComponent<NavMeshAgent>().destination = player.transform.position;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player && !isDeath && !isAttacking)
        {
            StartCoroutine(HitPlayer());
        }
    }

    public void Hit(float damage)
    {
        if (isDeath)
            return;
        
        shootController.PlayOneShot(shootClip);
        
        health -= damage;
        if (health <= 0)
        {
            Destroy(GetComponent<CapsuleCollider>());
            isDeath = true;
            StartCoroutine(Die());
             
            int randomNumber = UnityEngine.Random.Range(0, 10);

            if (randomNumber <= itemProb)
            {
                
                float playerHealth = player.GetComponent<PlayerManager>().health;

                Quaternion rotation = Quaternion.Euler(-90, 0, 0);
                Vector3 itemPos = transform.position + new Vector3(0, 3, 0);
                
                if (playerHealth < 100)
                {
                    Instantiate(healthItem, itemPos, rotation); 
                }
                else
                {
                    Instantiate(powerUPItem, itemPos, rotation); 
                }
                

            }
            
            gameManager.enemiesAlive--;
        }
    }

 
    
    IEnumerator Die()
    {
        enemyAnimator.SetTrigger("death");
        GetComponent<NavMeshAgent>().enabled = false;
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    
    IEnumerator HitPlayer()
    {
        hitController.PlayOneShot(hitClip);
        isAttacking = true;
        enemyAnimator.SetBool("attack", true);
        yield return new WaitForSeconds(0.25f);
        player.GetComponent<PlayerManager>().Hit(damage);
        enemyAnimator.SetBool("attack", false);
        yield return new WaitForSeconds(2f);
        isAttacking = false;
    }
}
 