
using System;
using UnityEngine;

public class PlatformEntrance : MonoBehaviour
{
    public static event Action<Platform> OnPlayerEnteredPlatform;
    [SerializeField] private Platform _platform;
    [SerializeField] private Collider _collider;

    public void ResetEntrance()
    {
        _collider.enabled = true; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterController character))
        {
            _collider.enabled = false;
            OnPlayerEnteredPlatform?.Invoke(_platform);
        }
    }
}
