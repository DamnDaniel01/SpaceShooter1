using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject[] Enemies;

    int randomSpawnPoint, randomEnemy;

    public static bool spawnAllowed;

    int ValueMax;

    // Use this for initialization
    void Start()
    {
        spawnAllowed = true;

        InvokeRepeating ("SpawnAnEnemy", 0f, 1f);
    }

    void SpawnAnEnemy()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);


            Instantiate(Enemies[randomEnemy], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }

    void Update()
    {
        randomEnemy = Random.Range(0 , ValueMax);

        if (Score.scoreValue > 20)
        {
            ValueMax = 2;
        }    

        if (Score.scoreValue > 40)
        {
            ValueMax = 3;
        }

        if (Score.scoreValue > 60)
        {
            ValueMax = 4;
        }
    }
}
