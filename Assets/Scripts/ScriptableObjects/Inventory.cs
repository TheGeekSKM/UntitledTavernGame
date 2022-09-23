using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "")]
public class Inventory : ScriptableObject
{
    public int _numOfBones;

    public void AddBones(int bones)
    {
        _numOfBones += bones;
    }
    public void AddBone()
    {
        _numOfBones++;
    }
}
