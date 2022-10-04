using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BulletController : MonoBehaviour
{
    [SerializeField] private int _bulletDamage = 1;
    [SerializeField] Rigidbody2D _rB;
    [SerializeField, HighlightIfNull] GameObject _particles;
    [SerializeField] LayerMask _maskToIgnore;

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
        Instantiate(_particles, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer != _maskToIgnore) {Instantiate(_particles, transform.position, Quaternion.identity);}
        
        IDamageable _damageable = other.gameObject.GetComponent<IDamageable>();
        if (_damageable != null && other.gameObject.layer != _maskToIgnore)
        {
            
            _damageable.Damage(_bulletDamage);
        }
       
       Destroy(gameObject);
    }


}
