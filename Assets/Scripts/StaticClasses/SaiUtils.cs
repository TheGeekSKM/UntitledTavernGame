using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        return _minTransform;
   }
}
