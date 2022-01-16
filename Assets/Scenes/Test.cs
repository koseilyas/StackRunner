using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Transform platform;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CubeCut.Cut(platform, Vector3.left,true);
        }
        
    }
}
