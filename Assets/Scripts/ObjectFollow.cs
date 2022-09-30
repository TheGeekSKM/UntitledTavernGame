using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour{
    [SerializeField] private List<Transform> _targets = new List<Transform>();
    [SerializeField] bool _isRangedEnemy = false;
    [SerializeField, ShowIf("_isRangedEnemy")] float _attackRange = 5f; 
    [SerializeField, ShowIf("_isRangedEnemy")] bool _isShooting = false; 
    [SerializeField] bool _isBoss = false;
    [SerializeField] bool _onlyTriggerPlayer = false;
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
    float _tempMoveSpeed;

    // Start is called before the first frame update
    void Start(){
        rb = this.GetComponent<Rigidbody2D>();
        _tempMoveSpeed = moveSpeed;
    }
    public void PopulateList(List<Transform> _l)
    {
        _targets = _l;
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
        Vector2 direction = Vector2.zero;
        //Find the closest target
        if (_targets.Count > 0 && transform != null && !_onlyTriggerPlayer)
        {
            _currentTarget = SaiUtils.GetClosestTransform(TimeManager.Instance.GetTargets(), transform);
        }
        else
        {
            _currentTarget = TimeManager.Instance.GetTargets()[0];
        }

        if (_currentTarget != null) { direction = _currentTarget.position - transform.position;}
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        if (movement == null || rb == null)
        {
            return;
        }
        if (movement == null) { movement = Vector2.zero; }

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
                rb.MovePosition((Vector2)transform.position + (moveSpeed * Time.deltaTime * movement));
            }
        }
        else
        {
            rb.MovePosition((Vector2)transform.position + (moveSpeed * Time.deltaTime * movement));
        }
    }

    void MoveCharacterFunction(Vector2 direction){
        if (direction == null) {direction = Vector2.zero;}
        
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
                rb.MovePosition((Vector2)transform.position + (moveSpeed * Time.deltaTime * direction));
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
                rb.MovePosition((Vector2)transform.position + (moveSpeed * Time.deltaTime * direction));
            }
        }
        else
        {
            rb.MovePosition((Vector2)transform.position + (moveSpeed * Time.deltaTime * direction));
        }
        
    }

    public void SetTarget(Transform transform)
    {
        _currentTarget = transform;
    }
}