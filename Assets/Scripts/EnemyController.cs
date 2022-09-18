using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _enemyHealth = 5;
    public int EnemyHealth 
    {
        get {return _enemyHealth;}
        set {_enemyHealth = value;}
    }

    public void Damage(int _dmg)
    {
        _enemyHealth -= _dmg;
        if (_enemyHealth <= 0) { Die(); }
    }

    public void Die()
    {
        Debug.Log("Enemy Died!");
        Destroy(gameObject);
    }

}
