using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickUp : PickupBase
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            var _tempMovement = collision.gameObject.GetComponent<PlayerMovement>();
            _tempMovement.MoveSpeed += value;
        }
        Destroy(gameObject);
    }
}
