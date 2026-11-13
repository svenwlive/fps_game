using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This enemy spawner does not work 100% properly, as spawned enemies don't follow the player and just stand still.
//However it works when the assigned enemy prefab is from the same level, but stops working when the same prefab is destroyed

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;
    public Vector3 spawnArea = new Vector3(10, 5, 10);

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnRate);     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector3 randomPos = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            Random.Range(1, spawnArea.y),
            Random.Range(-spawnArea.z, spawnArea.z)
        );

        Instantiate(enemyPrefab, randomPos, Quaternion.identity);
    }
}
