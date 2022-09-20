using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    public TIME _currentTime = TIME.DAY;
    private Timer _timer;

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
        if (_timer.hourlyTimeNumber == new Vector2(6f, 0f)) 
        {
            _currentTime = TIME.DAY;
            // _timer.stopTimer = true;
        }
        else if (_timer.hourlyTimeNumber == new Vector2(20f, 0f)) {_currentTime = TIME.NIGHT;}
    }


    public void SwitchToNight()
    {
        _currentTime = TIME.NIGHT;
        _timer.timeCurrently = 1200f;
    }
    public void SwitchToDay()
    {
        _currentTime = TIME.DAY;
        _timer.timeCurrently = 360f;
    }    
    public void SwitchTime()
    {
        if (_currentTime == TIME.DAY) {SwitchToNight();}
        else {SwitchToDay();}
    }
}
