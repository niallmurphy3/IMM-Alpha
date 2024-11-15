using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int waveCount = 2;
    public int enemyCount;
    public GameObject powerupPrefab;
    public GameObject enemyPrefab;
    private float spawnRange = 8;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveCount);
        Instantiate(powerupPrefab, GenerateSpawnPosition(),powerupPrefab.transform.rotation);
    }
    
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(),
            enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Powerup Enemy").Length;
        if (enemyCount == 0) { waveCount++; SpawnEnemyWave(waveCount); Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); }
    }
}
