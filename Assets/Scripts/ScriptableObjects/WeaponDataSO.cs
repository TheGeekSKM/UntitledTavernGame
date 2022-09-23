using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UntitledTavernGame/WeaponDataSO")]
public class WeaponDataSO : ScriptableObject
{
    public string weaponName = "Untitled Weapon";
    [TextArea]
    public string description = "This does untitled things to unnamed beings!";
    public Sprite _weaponSprite;

    public GameObject _bulletPrefab;
    public float _fireForce = 20f;
    public int _weaponDamage = 1;

    public void FireGun(Transform _firePoint)
    {
      GameObject _bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
      BulletController _bC = _bullet.GetComponent<BulletController>();

      if (_bC != null) { _bC.BulletDamage += _weaponDamage; }

      _bullet.GetComponent<Rigidbody2D>().AddForce(_firePoint.up * _fireForce, ForceMode2D.Impulse);
    }

}
