using System.Collections;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _followCam, _rotateCam;
    private WaitForEndOfFrame _frame = new WaitForEndOfFrame();
    private CinemachineTrackedDolly _trackedDolly;

    private void OnEnable()
    {
        DancingState.OnStartDancing += ActivateRotateCam;
        _trackedDolly = _rotateCam.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    private void ActivateRotateCam()
    {
        _rotateCam.Priority = 100;
        _rotateCam.gameObject.SetActive(true);
        _followCam.gameObject.SetActive(false);
        StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        while (true)
        {
            _trackedDolly.m_PathPosition += (Time.deltaTime / 3f);
            yield return _frame;
        }
    }

    private void OnDisable()
    {
        DancingState.OnStartDancing -= ActivateRotateCam;
    }
}
