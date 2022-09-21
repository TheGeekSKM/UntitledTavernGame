using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum TIME
{
    DAY,
    NIGHT
}

public class TimeManager : MonoBehaviour
{
    //Responsibilities
    //1. Switch between day and night mode.
    //2. Switching to night mode activates spawners
    //3. ??

    public IntegerSO numOfDays;
    public int maxDays = 20;
    [SerializeField] int _maxSpawnDifficulty = 5;
    private bool _timeSwitchUpdate = false;
    public TIME _currentTime = TIME.DAY;


    [Header("References")]
    [SerializeField] private Timer _timer;
    [SerializeField] private List<EnemyNonWaveSpawner> _spawners = new List<EnemyNonWaveSpawner>();



    #region Singleton
    public static TimeManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    #endregion
        _timer = GetComponent<Timer>();
    }


    private void Start()
    {
        foreach (EnemyNonWaveSpawner e in _spawners)
        {
            e.TimeBetweenWaves = CalculateDifficulty(numOfDays.value);
            if (e.TimeBetweenWaves > _maxSpawnDifficulty) {e.TimeBetweenWaves = _maxSpawnDifficulty;}
            if (e.TimeBetweenWaves <= 0.1f) {e.TimeBetweenWaves = 0.1f;}

            e.MakeEnemiesHarder(numOfDays.value);
        }
    }

    void Update()
    {
         

        //Keep at Bottom
        if (_timer.hourlyTimeNumber == new Vector2(6f, 0f) || (_timer.timeCurrently >= 360f && _timer.timeCurrently < 1200f)) 
        {
            _currentTime = TIME.DAY;

            if (!_timeSwitchUpdate) 
            {
                OnTimeSwitch();
                _timeSwitchUpdate = true;
            }
            // _timer.stopTimer = true;
        }
        else if (_timer.hourlyTimeNumber == new Vector2(20f, 0f) || _timer.timeCurrently >= 1200f) 
        {
            _currentTime = TIME.NIGHT;
            _timeSwitchUpdate = false;
        }
    }

    void OnTimeSwitch()
    {
        numOfDays.value++;
        foreach (EnemyNonWaveSpawner e in _spawners)
        {
            e.TimeBetweenWaves = CalculateDifficulty(numOfDays.value);
            Debug.Log(e.TimeBetweenWaves);
            if (e.TimeBetweenWaves > _maxSpawnDifficulty) {e.TimeBetweenWaves = _maxSpawnDifficulty;}
            if (e.TimeBetweenWaves <= 0.1f) {e.TimeBetweenWaves = 0.1f;}

            e.MakeEnemiesHarder(numOfDays.value);
        }
    }

    public void SwitchToNight()
    {
        _timer.timeCurrently = 1200f;
    }
    public void SwitchToDay()
    {
        _timer.timeCurrently = 360f;
    }    
    public void SwitchTime()
    {
        if (_currentTime == TIME.DAY) {SwitchToNight();}
        else {SwitchToDay();}
    }

    float CalculateDifficulty(int numberOfDays)
    {
        Debug.Log($"Number of Days: {numberOfDays}");
        if (numberOfDays == 0) {return 5f;}
        float diff = ((1f / (float)numberOfDays) * 10f);
        Debug.Log($"diff is {diff}");
        float perc = diff * 0.75f;
        Debug.Log($"perc is {perc}");
        return (perc);
    }
}
