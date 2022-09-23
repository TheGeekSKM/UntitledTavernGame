using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] List<GameObject> _loot = new List<GameObject>();
    [SerializeField] float _chanceToDrop = 30f;
    public void LootDrop()
    {
        if (_loot.Count > 0)
        {
            foreach (GameObject g in _loot)
            {

                if (Random.Range(1f, 101f) < _chanceToDrop)
                {
                    Vector2 randLocation = new Vector2(transform.position.x + Random.Range(-7f, 7f), transform.position.y + Random.Range(-7f, 7f));
                    if (randLocation.x > 20f) {randLocation.x = 20f;}
                    if (randLocation.x < -20f) {randLocation.x = -20f;}
                    if (randLocation.y > 12f) {randLocation.y = 12f;}
                    if (randLocation.y < -12f) {randLocation.y = -12f;}
                    Instantiate(g, randLocation, Quaternion.identity);
                }
            }
        }
        
    }
}
