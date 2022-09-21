using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNonWaveSpawner : MonoBehaviour
{
    public bool canSpawn = true;
    [SerializeField, HighlightIfNull] GameObject _meleeEnemy;
    [SerializeField, HighlightIfNull] GameObject _rangedEnemy;
    [SerializeField, HighlightIfNull] GameObject _miniBossEnemy;
    [SerializeField] float _meleeSpawnPercentage = 60f;
    [SerializeField] float _rangedSpawnPercentage = 30f;
    [SerializeField] float _miniBossSpawnPercentage = 10f;
    public Transform firstPoint;
    public Transform secondPoint;
    [SerializeField] float _timeToSpawn;
    private float _timeBetweenWaves = 5f;
    [SerializeField, ReadOnly] int enemiesSpawned = 0;
    public int EnemiesSpawned => enemiesSpawned;
    public float TimeBetweenWaves 
    {
        get
        {
            return _timeBetweenWaves;
        } 
        set
        {
            _timeBetweenWaves = value;
        }
    }

    void OnDrawGizmosSelected()
    {
        foreach (Transform t in transform)
        {
            Gizmos.DrawWireSphere(t.position, 2);
        }
    }

    private void Update()
    {
        //Makes sure the spawn percentages never go above 100 by decreasing the MiniBoss and Ranged Enemy Spawns
        if ((_meleeSpawnPercentage + _rangedSpawnPercentage + _miniBossSpawnPercentage) > 100f)
        {
            float _totalPercentage = _meleeSpawnPercentage + _rangedSpawnPercentage + _miniBossSpawnPercentage;
            float _percentageDiff = _totalPercentage - 100;
            _miniBossSpawnPercentage -= 0.75f * _percentageDiff;
            _rangedSpawnPercentage -= 0.25f * _percentageDiff;
        }

        //Only allows Spawns at Night
        if (TimeManager.Instance._currentTime == TIME.NIGHT)
        {
            if (Time.time >= _timeToSpawn)
            {
                Spawn();
                _timeToSpawn = Time.time + Random.Range(0.1f, TimeBetweenWaves);
            }
        }
       
    }

    private void Spawn()
    {
        GameObject _enemyToSpawn = null;

        float _randomSpawnNum = Random.Range(1, 101);

        if (_randomSpawnNum < _miniBossSpawnPercentage) {_enemyToSpawn = _miniBossEnemy;}
        else if (_randomSpawnNum < _rangedSpawnPercentage) {_enemyToSpawn = _rangedEnemy;}
        else if (_randomSpawnNum < _meleeSpawnPercentage) {_enemyToSpawn = _meleeEnemy;}

        if (_enemyToSpawn != null)
        {
            Instantiate(_enemyToSpawn, new Vector2(
                Random.Range(firstPoint.position.x, secondPoint.position.x), 
                Random.Range(firstPoint.position.y, secondPoint.position.y)), 
                Quaternion.identity);
        }

        enemiesSpawned++;
        
       
    }

    public void MakeEnemiesHarder(int numberOfDays)
    {
        _meleeSpawnPercentage -= (numberOfDays * 2);
        _rangedSpawnPercentage += numberOfDays;
        _miniBossSpawnPercentage += numberOfDays;
    }

   
}

