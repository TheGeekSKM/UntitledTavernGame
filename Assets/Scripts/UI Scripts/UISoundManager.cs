using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundManager : MonoBehaviour
{
    [SerializeField] AudioClip _onHoverEnterAudio;
    [SerializeField] AudioClip _onHoverExitAudio;
    [SerializeField] AudioClip _onClickAudio;

    public void OnMouseEnterFunction()
    {
        Debug.Log($"Entered {gameObject.name}");
    }

    public void OnMouseExitFunction()
    {
        Debug.Log($"Exited {gameObject.name}");
    }

    public void OnMouseDownFunction()
    {
        Debug.Log($"Clicked on {gameObject.name}");
    }
}
