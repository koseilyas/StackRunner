using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        Platform.OnPerfectMatch += PerfectMatch;
    }
    
    private void OnDisable()
    {
        Platform.OnPerfectMatch -= PerfectMatch;
    }

    private void PerfectMatch(int streak)
    {
        _audioSource.pitch = 0.9f + streak * 0.08f;
        _audioSource.Play();
    }
}
