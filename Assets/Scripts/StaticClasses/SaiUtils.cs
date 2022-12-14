using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public static class SaiUtils
{
   public static Transform GetClosestTransform(List<Transform> _transforms, Transform _currentPosition)
   {
        Transform _minTransform = null;
        float _minDistance = Mathf.Infinity;

        foreach (Transform t in _transforms)
        {
            float dist = Vector2.Distance(t.position, _currentPosition.position); //Calculates Distance

            if (dist < _minDistance)
            {
                _minTransform = t;
                _minDistance = dist;
            }
        }
        if (_minTransform == null) { return _currentPosition; }
        else { return _minTransform; }
    }

   public static Transform GetClosestEnemy(List<EnemyBase> _components, Transform _currentPosition)
   {
        Transform _minTransform = null;
        float _minDistance = Mathf.Infinity;

        for (int i = 0; i < _components.Count; i++)
        {
            var _transform = _components[i].gameObject.transform;
            float _dist = Vector2.Distance(_transform.position, _currentPosition.position);

            if (_dist < _minDistance)
            {
                _minTransform = _transform;
                _minDistance = _dist;
            }
        }

        if (_minTransform == null) { return _currentPosition; }
        else { return _minTransform; }
   }

   public static bool IsMouseOverUi
    {
        get
        {
            var events = EventSystem.current;
            return events != null && events.IsPointerOverGameObject();
        }
    }
    public static void SwitchScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public static void SwitchNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
