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
            
            if (Random.Range(1f, 101f) < _chanceToDrop)
            {
                GameObject _itemToDrop = _loot[Random.Range(0, _loot.Count - 1)];
                Instantiate(_itemToDrop, transform.position, Quaternion.identity);
            }
        }
        
    }
}
