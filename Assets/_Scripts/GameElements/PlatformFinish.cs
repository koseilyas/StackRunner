
using System;
using UnityEngine;

public class PlatformFinish : MonoBehaviour
{
    public static event Action<Platform> OnPlayerEnteredFinishingPlatform;
    [SerializeField] private Platform _platform;
    [SerializeField] private Collider _collider;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterController character))
        {
            _collider.enabled = false;
            OnPlayerEnteredFinishingPlatform?.Invoke(_platform);
        }
    }
}
