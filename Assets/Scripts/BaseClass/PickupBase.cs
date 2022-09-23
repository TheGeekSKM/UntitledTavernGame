using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBase : MonoBehaviour
{
    [SerializeField] protected int value = 1;
    [SerializeField] protected UnityEvent _onPick;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _onPick?.Invoke();
        OnPickUp(collision);
        
    }

    protected virtual void OnPickUp(Collider2D collision)
    {
        Destroy(gameObject);
    }

   
}
