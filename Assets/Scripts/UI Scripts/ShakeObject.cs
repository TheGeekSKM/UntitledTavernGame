using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeObject : MonoBehaviour
{
    bool shaking = false;
    [SerializeField] float shakeTime = 0.25f;
    [SerializeField] float shakeAmt = 5;
    Vector3 _originalPos;
    float originalShakeAmount;

    void Start()
    {
        _originalPos = transform.position; 
        originalShakeAmount = shakeAmt;

    }

    void Update()
    {
        if (shaking)
        {
            Vector3 newPos = _originalPos + Random.insideUnitSphere * (Time.deltaTime * shakeAmt);
            newPos.z = transform.position.z;

            transform.position = newPos;
        }
    }
    public void ShakeMe()
    {
        StartCoroutine(ShakeNow());
    }

    public void ShakeMe(float _shakeAmount)
    {
        shakeAmt = _shakeAmount;
    }

    IEnumerator ShakeNow()
    {
        

        if (!shaking)
        {
            shaking = true;
        }

        yield return new WaitForSeconds(shakeTime);
        shaking = false;
        shakeAmt = originalShakeAmount;
        transform.position = _originalPos;
    }
}
