using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;
    public float range = Mathf.Infinity;
   

    public Animator playerAnimator;
    public GameObject shootEffect;
    public Transform shootPoint;
    
    public GameObject bulletPrefab;
    public float bulletSpeed = 4000f;
    
     public AudioSource shootController;
     public AudioClip shootClip;
 
    void Update()
    {
        // hacemos el efecto de mover el arma al disparar por el retroceso del arma
        if (playerAnimator.GetBool("isShooting"))
        {
            playerAnimator.SetBool("isShooting", false);
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            shootController.PlayOneShot(shootClip);
        }   
        
        
        
    }


    void Shoot()
    {
        playerAnimator.SetBool("isShooting", true);
        // RaycastHit hit;
         
        
        GameObject shootEffectClone = Instantiate(shootEffect, shootPoint.position, shootPoint.rotation);
        Destroy(shootEffectClone, 0.02f);
        
        GameObject bulletClone = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
         
        bulletClone.GetComponent<Rigidbody>().AddForce(playerCam.transform.forward * bulletSpeed);
        Destroy(bulletClone, 2f);
        
        
        
        /*
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range)) // con out indicamos que los datos que recibimos se guardaran en la variable hit
        {
            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
            if (enemyManager != null)
            {
                enemyManager.Hit(25);
            }
        } 
        */
        
    }
}
