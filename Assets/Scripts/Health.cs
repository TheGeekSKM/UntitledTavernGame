using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth;
    [SerializeField, ReadOnly] private int _currentHealth;
    [SerializeField] private bool _logHealth;
    public int CurrentHealth
    {
        get {return _currentHealth;}
        set {_currentHealth = value;}
    }

    [SerializeField] private bool resetHealthOnStart = true;


    private void Start()
    {
        if (resetHealthOnStart) { _currentHealth = _maxHealth; }
    }

  
    private void Update()
    {
        if (_logHealth) {Debug.Log(gameObject.name + "'s HP: " + _currentHealth);}
    }

    public void Damage(int _damageAmount)
    {
        _currentHealth -= _damageAmount;
        if (_currentHealth <= 0) { Die(); }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
   
}
