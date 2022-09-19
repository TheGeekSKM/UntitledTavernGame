using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private int _cost = 2;
    [SerializeField] public GameObject enemyPrefab; 
    public int Cost => _cost;
}
