using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerMini : MonoBehaviour
{
    [SerializeField, ReadOnly] float timeCurrently = 1200f;
    [SerializeField, ReadOnly] float timeMultiplier = 20f;
    [SerializeField, ReadOnly] bool _timeStop = false;
    [SerializeField] string _sceneName;

    void Update()
    {
        if (!_timeStop) {timeCurrently += Time.deltaTime * timeMultiplier;}
        
        if (timeCurrently >= 360 && timeCurrently <= 500)
        {
            _timeStop = true;
            Switch(_sceneName);
        }

        if (timeCurrently > 1440f ) 
        {
            timeCurrently = 0f;
        }
    }

    public void Switch(string name)
    {
        SceneManager.LoadScene(name);
    }
}
