using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCNames : MonoBehaviour
{
   [SerializeField] List<string> FirstNames = new List<string>();
   [SerializeField] List<string> LastNames = new List<string>();
   [SerializeField, HighlightIfNull] TextMeshPro _name;

   void Start()
   {
        string _first = FirstNames[Random.Range(0, FirstNames.Count - 1)];
        string _last = LastNames[Random.Range(0, FirstNames.Count - 1)];

        _name.text = $"{_first} {_last}";
   }

}
