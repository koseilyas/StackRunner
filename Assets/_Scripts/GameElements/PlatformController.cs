using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Platform _platformPrefab;
    [SerializeField] private Material[] _platformMaterials;
    private Vector3[] _platformSpawnPoints = new[] {new Vector3(6, -.25f, 0), new Vector3(-6, -.25f, 0)};
    [SerializeField]private List<Platform> _createdPlatforms = new List<Platform>();
    private int platformCounter = 1;

    private void OnEnable()
    {
        PlatformEntrance.OnPlayerEnteredPlatform += CreateNextPlatform;
        InputController.OnTapped += PlayerTaps;
    }
    

    private void OnDisable()
    {
        PlatformEntrance.OnPlayerEnteredPlatform -= CreateNextPlatform;
        InputController.OnTapped += PlayerTaps;
    }
    
    private void CreateNextPlatform(Platform oldPlatform)
    {
        platformCounter++;
        Platform newPlatform = Instantiate(_createdPlatforms[_createdPlatforms.Count-1], transform);
        newPlatform.name = $"platform{platformCounter}";
        int randomSpawnPointIndex = Random.Range(0, 2);
        newPlatform.transform.position = _platformSpawnPoints[randomSpawnPointIndex] + new Vector3(0, 0, oldPlatform.transform.position.z + 4.5f);
        Vector3 target = _platformSpawnPoints[(randomSpawnPointIndex+1)%2] + new Vector3(0, 0, oldPlatform.transform.position.z + 4.5f);
        newPlatform.Init(target);
        _createdPlatforms.Add(newPlatform);
    }
    
    private void PlayerTaps()
    {
        var lastPlatform = _createdPlatforms[_createdPlatforms.Count-1];
        lastPlatform.StopMoving();
        if (_createdPlatforms.Count > 1)
        {
            var previousPlatform = _createdPlatforms[_createdPlatforms.Count-2];
            lastPlatform.Trim(previousPlatform);
        }
    }
}