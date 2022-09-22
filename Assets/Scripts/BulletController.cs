using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private int _bulletDamage = 1;
    [SerializeField, ReadOnly] private bool _collided = false;
    [SerializeField] Rigidbody2D _rB;

    public int BulletDamage 
    {
        get {return _bulletDamage;}
        set {_bulletDamage = value;}
    }

    void OnValidate()
    {
        if (_rB == null) {_rB = GetComponent<Rigidbody2D>();}
    }
   
    
    private void Awake()
    {
        StartCoroutine("DestroyTime");    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _collided = true;

        IDamageable _damageable = other.gameObject.GetComponent<IDamageable>();
        if (_damageable != null)
        {
            _damageable.Damage(_bulletDamage);
        }
       

       Destroy(gameObject);
    }

   

    IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(lifeTime);
        if (!_collided) { Destroy(gameObject); }
    }
}
