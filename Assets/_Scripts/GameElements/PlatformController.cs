using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// There is a lot of magic numbers in this class.
/// We have 2 types of platform( normal platform and finishing platform) these numbers are their values.
/// </summary>
public class PlatformController : MonoBehaviour
{
    private Vector3[] _platformSpawnPoints = new[] {new Vector3(6, -.25f, 0), new Vector3(-6, -.25f, 0)};
    [SerializeField]private List<Platform> _createdPlatforms = new List<Platform>();
    [SerializeField] private Platform _finishingPlatform;
    [SerializeField] private int _maxPlatformCount;
    private int _platformCounter = 1;

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
        
        _platformCounter++;
        Platform newPlatform = Instantiate(_createdPlatforms[_createdPlatforms.Count-1], transform);
        newPlatform.name = $"platform{_platformCounter}";
        int randomSpawnPointIndex = Random.Range(0, 2);
        Vector3 target = Vector3.zero;
        if (_createdPlatforms.Count % _maxPlatformCount == 0)
        {
            CreateFinishingPlatform(oldPlatform);
        }
        else
        {
            InputController.canTakeInput = true;
            newPlatform.transform.localScale = new Vector3(_createdPlatforms[_createdPlatforms.Count - 1].transform.localScale.x, 0.5f, 4.5f);
            newPlatform.transform.position = _platformSpawnPoints[randomSpawnPointIndex] + new Vector3(0, 0, oldPlatform.transform.position.z + 4.5f);
            target = _platformSpawnPoints[(randomSpawnPointIndex+1)%2] + new Vector3(0, 0, oldPlatform.transform.position.z + 4.5f);
            newPlatform.Init(target);
            _createdPlatforms.Add(newPlatform);
        }
    }

    private void CreateFinishingPlatform(Platform oldPlatform)
    {
        Platform newPlatform = Instantiate(_finishingPlatform, transform);
        newPlatform.name = $"finishingPlatform";
        newPlatform.transform.localScale = new Vector3(3, 0.5f, 9f);
        newPlatform.transform.position =  new Vector3(0, -0.25f, oldPlatform.transform.position.z + 6.75f);
        Vector3 target =  new Vector3(0, -0.25f, oldPlatform.transform.position.z + 6.75f);
        newPlatform.Init(target);
        _createdPlatforms.Add(newPlatform);
    }

    private void PlayerTaps()
    {
        StartCoroutine(StopMoveTrim());
    }

    private IEnumerator StopMoveTrim()
    {
        var lastPlatform = _createdPlatforms[_createdPlatforms.Count-1];
        lastPlatform.StopMoving();
        if (_createdPlatforms.Count > 1)
        {
            var previousPlatform = _createdPlatforms[_createdPlatforms.Count - 2];
            yield return new WaitForEndOfFrame();
            lastPlatform.Trim(previousPlatform);
        }
    }
}