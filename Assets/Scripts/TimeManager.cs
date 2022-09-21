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
    [SerializeField] int _maxSpawnDifficulty = 7;
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
            e.Difficulty = ((maxDays + 0.5f) - numOfDays.value);
            if (e.Difficulty > _maxSpawnDifficulty) {e.Difficulty = _maxSpawnDifficulty;}
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
}
