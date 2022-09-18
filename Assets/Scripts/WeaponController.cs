using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
   [SerializeField] private GameObject _bulletPrefab;
   [SerializeField] private Transform _firePoint;
   [SerializeField] private float _fireForce = 20f;
   [SerializeField] private int _weaponDamage = 1;

   public int WeaponDamage 
   {
        get { return _weaponDamage; }
        set { _weaponDamage = value; }
   }

   public void Fire()
   {
        GameObject _bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        BulletController _bC = _bullet.GetComponent<BulletController>();

        if (_bC != null) { _bC.BulletDamage += _weaponDamage; }

        _bullet.GetComponent<Rigidbody2D>().AddForce(_firePoint.up * _fireForce, ForceMode2D.Impulse);
   }
}
