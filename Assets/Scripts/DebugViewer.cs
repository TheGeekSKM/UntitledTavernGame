using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugViewer : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] PlayerMovement _movement;
    [SerializeField] WeaponController _weapon;

    [SerializeField] TextMeshProUGUI _healthText;
    [SerializeField] TextMeshProUGUI _speedText;
    [SerializeField] TextMeshProUGUI _weaponDamageText;

    void Update()
    {
        _healthText.text = $"HP: {_health.CurrentHealth}";
        _speedText.text = $"Speed: {_movement.MoveSpeed}";
        _weaponDamageText.text = $"Weapon Damage: {_weapon.WeaponDamage}";
    }
}
