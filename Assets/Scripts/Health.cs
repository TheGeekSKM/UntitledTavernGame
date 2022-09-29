using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth;
    [SerializeField, ReadOnly] private int _currentHealth;
    [SerializeField] private bool _logHealth;
    [SerializeField] private bool _isNPC;

    [SerializeField] private UnityEvent OnDeath;
    public int CurrentHealth
    {
        get {return _currentHealth;}
        set {_currentHealth = value;}
    }

    [SerializeField] private bool resetHealthOnStart = true;


    private void Start()
    {
        if (resetHealthOnStart) { _currentHealth = _maxHealth; }
        if (_isNPC) { TimeManager.Instance.AddNPC(this.gameObject.transform); }
    }

  
    private void Update()
    {
        if (_logHealth) {Debug.Log(gameObject.name + "'s HP: " + _currentHealth);}
        if (_currentHealth <= 0) {Die();}
    }

    public void Damage(int _damageAmount)
    {
        _currentHealth -= _damageAmount;
        if (_currentHealth <= 0) { Die(); }
    }

    public void Die()
    {
        OnDeath?.Invoke();

        if (_isNPC) { TimeManager.Instance.RemoveNPC(this.gameObject.transform); }

        Destroy(gameObject);
    }
   
}
