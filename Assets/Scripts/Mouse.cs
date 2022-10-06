using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] Texture2D _mouseTexture;

    void Start()
    {
        Cursor.SetCursor(_mouseTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

//    void Update()
//    {   

//         transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
//    }
}
