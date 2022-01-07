using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject player;
    public bool isHeart = false;
    public bool isPowerUp = false;
    
    public GameObject bulletPrefab;
     
    public AudioSource soundController;
    public AudioClip sound;
    
    public bool isUsed = false;

   private void Start()
   {
       player = GameObject.FindGameObjectWithTag("Player");
   }

   private void Update()
   {
       gameObject.transform.Rotate(0, 0, 10);
       
       Vector3 playerPos = player.transform.position;
       Vector3 itemPos = transform.position;
        
       float distance = Vector3.Distance(playerPos, itemPos);
        
       
       if (distance < 2f)
       {
           ItemEffect();
       }
   }

 

   void ItemEffect()
   { 
       
       if (isHeart)
       {
           if (!isUsed)
           {
               player.GetComponent<PlayerManager>().health += 10;
               player.GetComponent<PlayerManager>().healthText.text = "Vida: " + player.GetComponent<PlayerManager>().health;
           }
         
           StartCoroutine(playSound());
       }
       else if (isPowerUp)
       {
           if (!isUsed)
           {
               bulletPrefab.GetComponent<Bullet>().damage += 0.5f;
           }
           
           StartCoroutine(playSound());
       }
       
   }
   
   IEnumerator playSound()
   {
       isUsed = true;
       soundController.PlayOneShot(sound);
       gameObject.GetComponent<MeshRenderer>().enabled = false;
       yield return new WaitForSeconds(1.5f);
       Destroy(gameObject);
   }
   
}

 