using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BulletController : MonoBehaviour
{
    [SerializeField] private int _bulletDamage = 1;
    [SerializeField] Rigidbody2D _rB;
    [SerializeField, HighlightIfNull] GameObject _normalParticles;
    [SerializeField, HighlightIfNull] GameObject _bloodSpurtParticle;
    [SerializeField] LayerMask _maskToIgnore;
    [SerializeField] AudioClip _clip;

    public int BulletDamage 
    {
        get {return _bulletDamage;}
        set {_bulletDamage = value;}
    }

    void OnValidate()
    {
        if (_rB == null) {_rB = GetComponent<Rigidbody2D>();}
    }


    void Start()
    {
        if (_normalParticles) {Instantiate(_normalParticles, transform.position, Quaternion.identity);}
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer != _maskToIgnore) {
            
            if (_clip != null && SoundManager.Instance) { SoundManager.Instance.PlaySound(_clip, 0.3f); }
        }
        
        IDamageable _damageable = other.gameObject.GetComponent<IDamageable>();
        if (_damageable != null && other.gameObject.layer != _maskToIgnore)
        {
            if (other.gameObject.GetComponent<Health>().IsLiving)
            {
                if (_bloodSpurtParticle != null) { Instantiate(_bloodSpurtParticle, transform.position, transform.rotation); }
            }
            else
            {
                Instantiate(_normalParticles, transform.position, Quaternion.identity);
            }
            _damageable.Damage(_bulletDamage);
        }
       
       Destroy(gameObject);
    }


}
