using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNonWaveSpawner : MonoBehaviour
{
    public bool canSpawn = true;
    public List<GameObject> _enemies = new List<GameObject>();
    public Transform firstPoint;
    public Transform secondPoint;
    [SerializeField] private float _timeToSpawn;
    [SerializeField] private float _timeBetweenWaves;
    [SerializeField, ReadOnly] private int enemiesSpawned = 0;
    public int EnemiesSpawned => enemiesSpawned;



    private void Update()
    {

        if (TimeManager.Instance._currentTime == TIME.NIGHT)
        {
            if (Time.time >= _timeToSpawn)
            {
                Spawn();
                _timeToSpawn = Time.time + _timeBetweenWaves;
            }
        }
       
    }

    private void Spawn()
    {
        int randomIndex = Random.Range(0, _enemies.Count);


        Instantiate(_enemies[randomIndex], new Vector2(
            Random.Range(firstPoint.position.x, secondPoint.position.x), 
            Random.Range(firstPoint.position.y, secondPoint.position.y)), 
            Quaternion.identity);

            enemiesSpawned++;
        //This basically spawns an object at a random index from the list above and spawns it at a random x, y, and z value that lies between the LeftMost and RightMost points
       
    }

   
}

