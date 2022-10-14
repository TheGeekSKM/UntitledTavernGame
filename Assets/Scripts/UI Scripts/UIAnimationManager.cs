using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationManager : MonoBehaviour
{
    [SerializeField] RectTransform _cachedOriginalTransform;
    [SerializeField] Vector3 _cachedFinalTransform;
    [SerializeField] Vector3 _startTransform;
    [SerializeField] bool _runOnStart = false;
    [SerializeField] bool _followObject;
    [SerializeField, ShowIf("_followObject"), HighlightIfNull] Transform _followObjectTransform;
    [SerializeField, ShowIf("_followObject")] float _followObjectTransformXOffset;
    [SerializeField, ShowIf("_followObject")] float _followObjectTransformYOffset;

    void OnValidate()
    {
        if (_cachedOriginalTransform == null) {_cachedOriginalTransform = GetComponent<RectTransform>();}
    }

    void Start()
    {
        if (_followObject && _followObjectTransform != null)
        {
            Vector3 _newTransform = new Vector3(_followObjectTransform.position.x + _followObjectTransformXOffset, 
                                        _followObjectTransform.position.y + _followObjectTransformYOffset, 0f);
            _cachedFinalTransform = _newTransform;
        }

        if (_runOnStart)
        {
            ExitAnimation(2f);
        }
    }
    
    
    public void IntroAnimation()
    {
        LeanTween.move(_cachedOriginalTransform, _cachedFinalTransform, 0.5f).setEase(LeanTweenType.easeInCubic);
    }

    public void ExitAnimation(float _time)
    {
        LeanTween.move(_cachedOriginalTransform, _startTransform, _time).setEase(LeanTweenType.easeInOutQuart);
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
