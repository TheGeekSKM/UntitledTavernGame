using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseActions : MonoBehaviour
{
    void OnMouseOver()
    {
        Debug.Log($"Mouse is hovering over {gameObject.name}");
    }
}
