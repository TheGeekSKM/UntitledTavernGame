using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] public float timeCurrently = 1200f;
    [SerializeField] public float timeMultiplier = 20f;
    [SerializeField, ReadOnly] public string hourlyTime = "";
    [SerializeField, ReadOnly] public Vector2 hourlyTimeNumber;
    [SerializeField, ReadOnly] public bool stopTimer = false;



    void Awake()
    {
        hourlyTimeNumber = new Vector2(0, 0);
    }

    void Update()
    {
        if (!stopTimer)
        {
            timeCurrently += Time.deltaTime * timeMultiplier;
        
            float minutes = Mathf.FloorToInt(timeCurrently / 60);
            float seconds = Mathf.FloorToInt(timeCurrently % 60);

            hourlyTimeNumber.x = minutes;
            hourlyTimeNumber.y = seconds;


            hourlyTime = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (hourlyTimeNumber == new Vector2(24f, 0f)) {timeCurrently = 0;}
        }
        
    }

    public void AddTime(float secondTime)
    {
        timeCurrently += secondTime;
    }
   
}
