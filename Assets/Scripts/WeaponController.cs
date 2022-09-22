using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public bool UseConstant;
    public WeaponSO ConstantValue;
    [SerializeField, HighlightIfNull] private WeaponSO _weapon;
    [SerializeField, HighlightIfNull] Transform _firePoint;

    public WeaponSO Weapon
    {
        get { return UseConstant ? ConstantValue : _weapon; }
    }
    public string WeaponName
    {
          get { return UseConstant ? ConstantValue.weaponName: _weapon.weaponName; }
    }
    public string WeaponDescription
    {
          get { return UseConstant ? ConstantValue.description: _weapon.description; }
    }
    public GameObject BulletPrefab
    {
          get { return UseConstant ? ConstantValue._bulletPrefab: _weapon._bulletPrefab; }
    }
    public float FireForce
    {
          get { return UseConstant ? ConstantValue._fireForce: _weapon._fireForce; }
    }
    public int WeaponDamage
    {
          get { return UseConstant ? ConstantValue._weaponDamage: _weapon._weaponDamage; }
    }

    public void Fire()
    {
          WeaponSO _weaponToUse = UseConstant ? ConstantValue : _weapon;
          if (_weaponToUse != null) {_weaponToUse.FireGun(_firePoint);}
    }
}
