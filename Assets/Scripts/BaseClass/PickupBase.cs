using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBase : MonoBehaviour
{
    [SerializeField] protected int value = 1;
    [SerializeField] protected UnityEvent _onPick;
    [SerializeField] GameObject _OnPickParticle;
    [SerializeField] AudioClip _clip; 



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _onPick?.Invoke();
            OnPickUp(collision);
        }
        
    }

    protected virtual void OnPickUp(Collider2D collision)
    {
        if (_clip != null && SoundManager.Instance) { SoundManager.Instance.PlaySound(_clip, 0.1f); }
        if (_OnPickParticle != null) {Instantiate(_OnPickParticle, transform.position, Quaternion.identity);}
        Destroy(gameObject);
    }

    void Update()
    {
        if (transform.position.x > 20) {transform.position = new Vector3(19f, transform.position.y, transform.position.z);}
    }

   
}
