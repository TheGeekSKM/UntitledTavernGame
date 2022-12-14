
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] public float timeCurrently = 1200f;
    [SerializeField] public float timeMultiplier = 20f;
    [SerializeField, ReadOnly] public string hourlyTime = "";
    [SerializeField, ReadOnly] public Vector2 hourlyTimeNumber;
    [SerializeField, ReadOnly] public bool stopTimer = false;
    [SerializeField] UnityEvent _onDayTime;
    [SerializeField] UnityEvent _onNightTime;



    void Awake()
    {
        hourlyTimeNumber = new Vector2(0, 0);
    }

    public void PauseTime()
    {
        stopTimer = true;
    }
    public void UnPauseTime()
    {
        stopTimer = false;
    }

    void Update()
    {
        //Debug.Log(stopTimer);
        if (!stopTimer)
        {
            timeCurrently += Time.deltaTime * timeMultiplier;

            
        }

        if (timeCurrently == 360f) { _onDayTime?.Invoke(); }
        if (timeCurrently == 1200f) { _onNightTime?.Invoke(); }

        float minutes = Mathf.FloorToInt(timeCurrently / 60);
        float seconds = Mathf.FloorToInt(timeCurrently % 60);

        hourlyTimeNumber.x = minutes;
        hourlyTimeNumber.y = seconds;


        hourlyTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timeCurrently > 1440f ) 
        {
            timeCurrently = 0f;
        }
        
    }

    public void AddTime(float secondTime)
    {
        timeCurrently += secondTime;
        if (timeCurrently > 1440f ) 
        {
            float tempTime = timeCurrently - 1440f;
            timeCurrently = tempTime;
        }
    }

    public void SetTime(TIME timeSetting)
    {
        if (timeSetting == TIME.DAY)
        {
            timeCurrently = 355f;
        }
        if (timeSetting == TIME.NIGHT)
        {
            timeCurrently = 1195f;
        }
    }
   
}
