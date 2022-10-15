using System.Runtime.Serialization;
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
        if (SoundManager.Instance && _onHoverEnterAudio != null) { SoundManager.Instance.PlaySound(_onHoverEnterAudio, 0.1f); }
    }

    public void OnMouseExitFunction()
    {
        if (SoundManager.Instance && _onHoverExitAudio != null) { SoundManager.Instance.PlaySound(_onHoverExitAudio, 0.1f); }

    }

    public void OnMouseDownFunction()
    {
        if (SoundManager.Instance && _onClickAudio != null) { SoundManager.Instance.PlaySound(_onClickAudio, 0.1f); }

    }
}
