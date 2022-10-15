using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSounds : MonoBehaviour
{
    [SerializeField, HighlightIfNull] AudioClip[] _footstepSounds;
    [SerializeField] PlayerMovement _movement;
    float footStepTimer = 0f;
    [SerializeField] float baseStepSpeed = 0.5f;
    [SerializeField] float volume = 0.5f; 
    [SerializeField] AudioSource _source;


    void OnValidate()
    {
        if (_movement == null) { _movement = GetComponent<PlayerMovement>(); }
        if (_source == null) { _source = GetComponent<AudioSource>(); }
    }
    
    void Start()
    {

    }

   void Update()
   {
        if (_movement.IsMoving)
        {
            footStepTimer -= Time.deltaTime;

            if (footStepTimer <= 0)
            {
                _source.PlayOneShot(_footstepSounds[Random.Range(0, _footstepSounds.Length)], volume);
                footStepTimer = baseStepSpeed;
            }
        }
   }
 }
