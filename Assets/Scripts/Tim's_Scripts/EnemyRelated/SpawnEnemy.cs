using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    LoseWinController loseWinController;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int[] MaxEnemies; // 20 30 50

    private int waveCount = 0;
    private int enemiesSpawned = 0;

    private Vector3 _spawnPosition;

    private void Start()
    {
        _spawnPosition = new Vector3(transform.position.x + 2f, transform.position.y + 4f, transform.position.z);
             
        loseWinController = FindAnyObjectByType<LoseWinController>();

        InvokeRepeating("SpawnEnemies", 3f, 1f);
    }

    private void SpawnEnemies()
    {
        if (MaxEnemies[waveCount] != 0)
        {
            if (enemiesSpawned % 10 == 0 && enemiesSpawned != 0)
            {
                Instantiate(enemies[2], _spawnPosition, Quaternion.identity);
            }
            else if (enemiesSpawned % 5 == 0 && enemiesSpawned != 0)
            {
                Instantiate(enemies[1], _spawnPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(enemies[0], _spawnPosition, Quaternion.identity);
            }

            MaxEnemies[waveCount]--;

            if (MaxEnemies[waveCount] <= 0)
            {
                enemiesSpawned = 0;
                CancelInvoke("SpawnEnemies");
                waveCount++;

                if (waveCount < MaxEnemies.Length)
                {
                    InvokeRepeating("SpawnEnemies", 20f, 1f);
                }
                else if(waveCount >= MaxEnemies.Length)
                {
                    Invoke(nameof(Win), 15f);
                }
                
            }
        }
     
    }  

    private void Win()
    {
        loseWinController.Win();
    }
}
