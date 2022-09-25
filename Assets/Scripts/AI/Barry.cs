using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barry : MonoBehaviour
{
    [SerializeField] float _finalXLocation;
    [SerializeField] float _initialXLocation;
    [SerializeField] float _speed;


    public void SummonBarry()
    {
        LeanTween.moveX(gameObject, _finalXLocation, _speed);
    }

    public void HideBarry()
    {
        LeanTween.moveX(gameObject, _initialXLocation, _speed);
    }
}
