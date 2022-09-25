using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationManager : MonoBehaviour
{
    [SerializeField] RectTransform _cachedOriginalTransform;
    [SerializeField] Vector3 _cachedFinalTransform;
    [SerializeField] Vector3 _startTransform;

    void OnValidate()
    {
        if (_cachedOriginalTransform == null) {_cachedOriginalTransform = GetComponent<RectTransform>();}
    }

    
    
    public void IntroAnimation()
    {
        LeanTween.move(_cachedOriginalTransform, _cachedFinalTransform, 2f).setEase(LeanTweenType.easeInOutQuart);
    }

    public void ExitAnimation()
    {

    }

    public void IntroAndExitAnimation(float _timeToWait)
    {
        StartCoroutine(Animation(_timeToWait));
    }

    IEnumerator Animation(float timeWait)
    {
        LeanTween.move(_cachedOriginalTransform, _cachedFinalTransform, 1f).setEase(LeanTweenType.easeInOutQuart);
        yield return new WaitForSeconds(timeWait);
        LeanTween.move(_cachedOriginalTransform, _startTransform, 1f).setEase(LeanTweenType.easeInOutQuart);

        
    }
}
