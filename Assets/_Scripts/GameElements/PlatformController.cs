using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Platform _platformPrefab;
    [SerializeField] private Material[] _platformMaterials;
    private Vector3[] _platformSpawnPoints = new[] {new Vector3(6, 0.25f, 0), new Vector3(-6, 0.25f, 0)};

    private void OnEnable()
    {
        Platform.OnPlayerEnteredPlatform += CreateNextPlatform;
    }

    private void OnDisable()
    {
        Platform.OnPlayerEnteredPlatform -= CreateNextPlatform;
    }
    
    private void CreateNextPlatform(Platform platform)
    {
        
    }
}