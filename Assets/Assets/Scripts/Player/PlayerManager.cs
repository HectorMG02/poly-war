using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health = 100;
    public Text healthText;
    
    public GameManager gameManager;
    
    public AudioSource[] soundControllers; 

    private void Start()
    {
        soundControllers[UnityEngine.Random.Range(0, soundControllers.Length)].loop = true;
        soundControllers[UnityEngine.Random.Range(0, soundControllers.Length)].Play();
    }

    public void Hit(float damage)
    {
        health -= damage;
        string healthTextValue = health < 0 ? "0" : health.ToString();
        healthText.text = "Vida: " + healthTextValue;

        if (health > 50)
        {
            healthText.color = Color.green;
        }
        if (health <= 50)
        {
            healthText.color = Color.yellow;
        } 
        if (health <= 25)
        {
            healthText.color = Color.red;
        }
        
        if(health <= 0)
        {
            gameManager.GameOver(); 
        }
    }
    
  
}
