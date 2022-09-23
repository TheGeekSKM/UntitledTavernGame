using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : PickupBase
{
    protected override void OnPickUp(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            var _tempHealth = collision.gameObject.GetComponent<Health>();
            _tempHealth.CurrentHealth += value;
        }
        base.OnPickUp(collision);
    }
}
