using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour{
    // [SerializeField] private List<Transform> _targets = new List<Transform>();
    [SerializeField] bool _isRangedEnemy = false;
    [SerializeField, ShowIf("_isRangedEnemy")] float _attackRange = 5f; 
    [SerializeField, ShowIf("_isRangedEnemy")] bool _isShooting = false; 
    [SerializeField] bool _isBoss = false;
    [SerializeField, ShowIf("_isBoss")] float _shootingRange = 15f;
    public bool IsShooting 
    {
        get
        {return _isShooting;}
    }

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;
    private Transform _currentTarget;
    private GameObject _player;
    float _tempMoveSpeed;

    // Start is called before the first frame update
    void Start(){
        rb = this.GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _tempMoveSpeed = moveSpeed;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        if (_isRangedEnemy) {Gizmos.DrawWireSphere(transform.position, _attackRange);}
        Gizmos.color = Color.blue;
        if (_isBoss) {Gizmos.DrawWireSphere(transform.position, _shootingRange);}
    }

    // Update is called once per frame
    void Update()
    {
        //Find the closest target
        // if (_targets.Count > 0) 
        // {
        //     _currentTarget = SaiUtils.GetClosestTransform(_targets, transform);
        // }

        if (_player != null) 
        {
            _currentTarget = _player.transform;
        }
        else 
        {
            _currentTarget = transform;
        }

        Vector2 direction = _currentTarget.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate() {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction){
        if (_isRangedEnemy)
        {
            
            if (Vector2.Distance(transform.position, _currentTarget.position) <= _attackRange)
            {
                moveSpeed = 0f;
                _isShooting = true;
            }
            else
            {
                _isShooting = false;
                moveSpeed = _tempMoveSpeed;
                rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
            }
        }
        else if (_isBoss)
        {
            if (Vector2.Distance(transform.position, _currentTarget.position) <= _shootingRange) {_isShooting = true;}
            else {_isShooting = false;}

            if (Vector2.Distance(transform.position, _currentTarget.position) <= _attackRange)
            {
                moveSpeed = 0f;
            }
            else
            {
                moveSpeed = _tempMoveSpeed;
                rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
            }
        }
        else
        {
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        }
        
    }

    public void SetTarget(Transform transform)
    {
        _currentTarget = transform;
    }
}