using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _audioSource.Play();
        }
    }
}
