using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;


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
    private bool _timeSwitchNightUpdate = false;
    public TIME _currentTime = TIME.DAY;

    [Header("Resource Collection")]
    [SerializeField] float _timeToCollectBones;

    [Header("Trap Settings")]
    [SerializeField] int _amountOfBonesToMakeTrap;
    [SerializeField] int _amountOfBonesToFixTrap;
    [SerializeField] float _timeToPlaceTrap;
    [SerializeField] float _timeToFixTrap;
    
    [Header("References")]
    [SerializeField] UnityEvent _onTimeSwitchDay;
    [SerializeField] UnityEvent _onTimeSwitchNight;
    [SerializeField] Inventory _playerInventory;
    [SerializeField, HighlightIfNull] GameObject _dayTimeMenu;
    [SerializeField] private Timer _timer;
    [SerializeField] private List<EnemyNonWaveSpawner> _spawners = new List<EnemyNonWaveSpawner>();
    [SerializeField] bool showDebug = false;
    bool rand = false;
    [SerializeField, ShowIf("showDebug")] private TextMeshProUGUI _debugDayText;



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
        rand = showDebug;
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
        if (_debugDayText != null) {_debugDayText.text = $"Day: {numOfDays.value}, Time: {_timer.hourlyTime}";}
        
         if (numOfDays.value > 20) {SceneManager.LoadScene("WinScreen");}
        //Keep at Bottom
        CheckTime();
    
        //TODO Consider this...
        // if (_currentTime == TIME.DAY) {_timer.stopTimer = true;}
        // else {_timer.stopTimer = false; }

        if (_currentTime == TIME.DAY) {_dayTimeMenu.SetActive(true);}
        else {_dayTimeMenu.SetActive(false); }
    }

    #region DayTime Buttons


    public void CollectBones()
    {
        int _numTotalEnemiesSpawned = 0;
        foreach (EnemyNonWaveSpawner e in _spawners)
        {
            _numTotalEnemiesSpawned += e.EnemiesSpawned;
        }
        int bonesCollected = Random.Range(0, _numTotalEnemiesSpawned);
        _playerInventory.AddBones(bonesCollected);
        Debug.Log($"You collected {bonesCollected} bones, and it is now night time!");
        _timer.SetTime(TIME.NIGHT);
        
    }
    public void PlaceTraps()
    {
        Debug.Log("WIP");
    }

    public void FixTrapsPlaced()
    {
        Debug.Log("WIP");
    }
   


    #endregion

    void OnTimeSwitch()
    {
        Debug.Log("IT IS DAY!");
        _onTimeSwitchDay?.Invoke();
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

    void OnTimeSwitchNight()
    {
        _onTimeSwitchNight?.Invoke();
        Debug.Log("IT IS NIGHT");
    }

   
    public void SwitchTime()
    {
        _timer.AddTime(720f);
        Debug.Log(_timer.timeCurrently);
        CheckTime();
        
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

    public void OnPlayerDeath()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    public void CheckTime()
    {
        if (_timer.hourlyTimeNumber == new Vector2(6f, 0f) || (_timer.timeCurrently >= 360f && _timer.timeCurrently < 1200f)) 
        {
            _currentTime = TIME.DAY;


            if (!_timeSwitchUpdate) 
            {
                OnTimeSwitch();
                _timeSwitchUpdate = true;
                _timeSwitchNightUpdate = false;
            }
            // _timer.stopTimer = true;
        }
        else if (_timer.hourlyTimeNumber == new Vector2(20f, 0f) || _timer.timeCurrently >= 1200f) 
        {
            _currentTime = TIME.NIGHT;

            if (!_timeSwitchNightUpdate)
            {
                OnTimeSwitchNight();
                _timeSwitchNightUpdate = true;
                _timeSwitchUpdate = false;
            }

            


        }
    }

    

}
