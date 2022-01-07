using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public int enemiesAlive = 0;
    public int round = 0;
    public int enemiesToSpawn = 0;
    public GameObject[] spawnPoints;
    public GameObject[] enemiesPrefabs;
    public Text roundText;
    
    public GameObject endScreen;
    public Text roundsSurvived;

    void Update()
    {
        if (enemiesAlive == 0)
        {
            round++;
            roundText.text = "Ronda: " + round;
            NextWave(round);
        }
    }

    public void NextWave(int round)
    {
        GameObject lastPoint = spawnPoints[0];

        if (round < 10)
        {
            enemiesToSpawn = round;
        }

        if (round % 10 == 0)
        {
            enemiesToSpawn = 1;
        }

        if (round > 10 && round % 10 != 0)
        {
            enemiesToSpawn++;
        }
        
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            if (lastPoint == spawnPoint)
            {
                i--;
            }
            else
            {
                int RandomEnemy = Random.Range(0, enemiesPrefabs.Length);
                
                lastPoint = spawnPoint;
                GameObject enemySpawned = Instantiate(enemiesPrefabs[RandomEnemy], spawnPoint.transform.position, Quaternion.identity);

                enemySpawned.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();

                enemiesAlive++; 
            }
        }

         
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None; // dejamos que el jugador pueda volver a ver el cursor
        roundsSurvived.text = round.ToString();
        endScreen.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(1); // reiniciamos el juego poniendo la misma escena
    }
    
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
