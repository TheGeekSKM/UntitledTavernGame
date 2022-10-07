using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UntitledTavernGame/IntegerSO")]
public class IntegerSO : ScriptableObject
{
    public int value;

    public void AddValue(int num)
    {
        value += num;
    }
}

