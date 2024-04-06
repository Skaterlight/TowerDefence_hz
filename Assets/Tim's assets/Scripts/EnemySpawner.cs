using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float MinTime, MaxTime;
    private float CoordX = 0.5f, CoordY = 1.3f;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0.3f, Random.Range(MinTime, MaxTime));
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, new Vector3(gameObject.transform.position.x + CoordX, gameObject.transform.position.y + CoordY, gameObject.transform.position.z), Quaternion.identity);
    }
}
