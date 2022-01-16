
using System;
using UnityEngine;

public class PlatformEntrance : MonoBehaviour
{
    public static event Action<Platform> OnPlayerEnteredPlatform;
    [SerializeField]private Platform _platform;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterController character))
        {
            OnPlayerEnteredPlatform?.Invoke(_platform);
        }
    }
}
