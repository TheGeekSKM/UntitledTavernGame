using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : PickupBase
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            var _tempHealth = collision.gameObject.GetComponent<Health>();
            _tempHealth.CurrentHealth += value;
        }
        Destroy(gameObject);
    }
}
