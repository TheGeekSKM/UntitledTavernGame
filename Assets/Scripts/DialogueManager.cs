using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] IntegerReference _numberOfDays;
    bool _cutsceneOneTriggered = false;
    bool _cutsceneTwoTriggered = false;

    void Update()
    {
        if (_numberOfDays.Value == 1 && !_cutsceneOneTriggered)
        {
            Debug.Log("Play Cutscene 1");
            _cutsceneOneTriggered = true;
        }

        if (_numberOfDays.Value == 7 && !_cutsceneTwoTriggered)
        {
            //Introduce NPCS
            Debug.Log("Introduce NPCs");
            _cutsceneTwoTriggered = true;
        }
    }
}
