using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Enemy> _enemies = new List<Enemy>();
    public int currentWave;
    public int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform spawnLocationFirstPosition;
    public Transform spawnLocationSecondPosition;
    private int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;

    private void Start()
    {
        GenerateWaves();
    }

    private void FixedUpdate()
    {
        if (spawnTimer <= 0)
        {
            if (enemiesToSpawn.Count > 0)
            {
                int randomIndex = Random.Range(0, enemiesToSpawn.Count);

                //Picks a random location between two points
                Vector2 _spawnLocation = new Vector2(Random.Range(spawnLocationFirstPosition.position.x , spawnLocationSecondPosition.position.x),
                    Random.Range(spawnLocationFirstPosition.position.y, spawnLocationSecondPosition.position.y));

                Instantiate(enemiesToSpawn[randomIndex], _spawnLocation, Quaternion.identity);
                enemiesToSpawn.RemoveAt(randomIndex);
                spawnTimer = spawnInterval;
            }
            else
            {
                waveTimer = 0;
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
    }

    public void GenerateWaves()
    {
        waveValue = currentWave * 10;
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count;
        waveTimer = waveDuration;
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0)
        {
            int randEnemyID = Random.Range(0, _enemies.Count);
            int randEnemyCost = _enemies[randEnemyID].cost;

            if (waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(_enemies[randEnemyID].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }
}

[System.Serializable]
public class Enemy
{
    [SerializeField] public int cost = 2;
    [SerializeField] public GameObject enemyPrefab; 
}

