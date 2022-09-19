using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyBase
{
    [SerializeField] private int _enemyDamage = 1;
    [SerializeField] private Rigidbody2D _rB;

    
    private void Start()
    {
        _rB = GetComponent<Rigidbody2D>();
    }
    public int EnemyDamage
    {
        get {return _enemyDamage;}
        set {_enemyDamage = value;}
    }
   void OnCollisionEnter2D(Collision2D other)
   {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        if (damageable != null && !other.gameObject.CompareTag("Enemy"))
        {
            damageable.Damage(_enemyDamage);
        }
   }
}
