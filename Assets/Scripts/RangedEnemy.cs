using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : EnemyBase
{
    public float startTimeBetweenShots = 2f;
    float _timeBetweenShots;

    [SerializeField] WeaponController _weapon;
    [SerializeField] ObjectFollow _follow;

    void OnValidate()
    {
        if (_weapon == null) {_weapon = GetComponentInChildren<WeaponController>();}
        if (_follow == null) {_follow = GetComponent<ObjectFollow>();}
    }

    void Update()
    {
        if ((_weapon != null) && (_follow != null))
        {
            if (_follow.IsShooting)
            {
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        if (_timeBetweenShots <= 0)
        {
            _weapon.Fire();
            _timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            _timeBetweenShots -= Time.deltaTime;
        }
    }
}
