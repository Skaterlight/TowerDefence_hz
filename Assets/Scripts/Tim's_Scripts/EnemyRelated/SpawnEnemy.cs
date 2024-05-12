using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    LoseWinController loseWinController;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int[] MaxEnemies;
    private int waveCount = 0;
    private int enemiesSpawned = 0;

    private void Start()
    {
        loseWinController = FindAnyObjectByType<LoseWinController>();

        InvokeRepeating("SpawnEnemies", 3f, 1f);
    }

    private void SpawnEnemies()
    {
        if (MaxEnemies[waveCount] != 0)
        {
            if (enemiesSpawned % 10 == 0 && enemiesSpawned != 0)
            {
                Instantiate(enemies[2], new Vector3(transform.position.x + 2f, transform.position.y + 4f, transform.position.z),
                    Quaternion.identity);
            }
            else if (enemiesSpawned % 5 == 0 && enemiesSpawned != 0)
            {
                Instantiate(enemies[1], new Vector3(transform.position.x + 2f, transform.position.y + 4f, transform.position.z),
                    Quaternion.identity);
            }
            else
            {
                Instantiate(enemies[0], new Vector3(transform.position.x + 2f, transform.position.y + 4f, transform.position.z),
                    Quaternion.identity);
            }

            enemiesSpawned++;

            if (MaxEnemies[waveCount] == enemiesSpawned)
            {
                enemiesSpawned = 0;
                CancelInvoke("SpawnEnemies");
                if (waveCount < MaxEnemies.Length && MaxEnemies[waveCount + 1] != 0)
                {
                    InvokeRepeating("SpawnEnemies", 20f, 1f);
                }
                if(waveCount == MaxEnemies.Length)
                {
                    StartCoroutine("ShowWin");
                }
                waveCount++;
            }
        }
        else
        {
            waveCount++;
            CancelInvoke("SpawnEnemies");
            if (waveCount < MaxEnemies.Length)
            {
                InvokeRepeating("SpawnEnemies", 30f, 1f);
            }
            if(waveCount == MaxEnemies.Length)
            {
                loseWinController.Win();
            }
        }
    }

    IEnumerator ShowWin()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            StopCoroutine("ShowWin");
            loseWinController.Win();
        }

        yield return null;
    }
}
