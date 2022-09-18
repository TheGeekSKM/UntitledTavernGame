using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private int _bulletDamage = 1;
    [SerializeField, ReadOnly] private bool _collided = false;

    public int BulletDamage 
    {
        get {return _bulletDamage;}
        set {_bulletDamage = value;}
    }
    
    private void Awake()
    {
        StartCoroutine("DestroyTime");    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _collided = true;

        EnemyController _enemy = other.gameObject.GetComponent<EnemyController>();
        if (_enemy != null)
        {
            _enemy.Damage(_bulletDamage);
        }

       Destroy(gameObject);
    }

    IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(lifeTime);
        if (!_collided) { Destroy(gameObject); }
    }
}
