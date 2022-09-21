using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


[Serializable]
public class IntegerReference
{
    public bool UseConstant;
    public int ConstantValue;
    public IntegerSO Variable;

    public int Value
    {
        get { return UseConstant ? ConstantValue : Variable.value; }
    }
}
