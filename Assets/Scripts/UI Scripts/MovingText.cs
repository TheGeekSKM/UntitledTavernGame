using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MovingText : MonoBehaviour
{
    [SerializeField] float _finalYPos = -540;
    [SerializeField] float speed = 1f;
    [SerializeField] UnityEvent _doneMoving;
    bool runOnce = false;
    float tempVal;

    void Start()
    {
        tempVal = speed;
    }


    void Update()
    {
        if (transform.position.y > _finalYPos)
        {
            transform.position = new Vector3(transform.position.x, _finalYPos, transform.position.z);
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) )
        {
            speed = 0.01f;
        }
        else
        {
            speed = tempVal;
        }
        if (transform.position.y < _finalYPos)
        {
            transform.position += new Vector3(0, speed, 0);
        }
        else
        {
            if (!runOnce)
            {
                _doneMoving?.Invoke();
                runOnce = true;
            }
        }
    }
}
