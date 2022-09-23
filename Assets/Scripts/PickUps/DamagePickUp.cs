using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePickUp : PickupBase
{
    protected override void OnPickUp(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<WeaponController>() != null)
        {
            var _tempHealth = collision.gameObject.GetComponentInChildren<WeaponController>();
            if (_tempHealth != null) { _tempHealth.Weapon._weaponDamage += value; }
        }
        Destroy(gameObject);
    }
}
