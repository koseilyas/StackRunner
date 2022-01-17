using System.Collections;
using UnityEngine;

public class UserInterfaceController : MonoBehaviour
{
    [SerializeField] private Canvas _levelFinishedCanvas;
    [SerializeField] private GameObject _levelEndScreen;
    [SerializeField] private GameObject _popupLevelWin;
    [SerializeField] private GameObject _popupLevelLose;

    private void OnEnable()
    {
        FallingState.OnPlayerFall += PlayerDead;
        DancingState.OnStartDancing += PlayerWin;
    }

    private void OnDisable()
    {
        FallingState.OnPlayerFall -= PlayerDead;
        DancingState.OnStartDancing -= PlayerWin;
    }

    private void PlayerWin()
    {
        StartCoroutine(EnableCanvas());
        _popupLevelWin.SetActive(true);
    }
    
    private void PlayerDead()
    {
        StartCoroutine(EnableCanvas());
        _popupLevelLose.SetActive(true);
    }

    private IEnumerator EnableCanvas()
    {
        yield return new WaitForSeconds(1);
        _levelFinishedCanvas.gameObject.SetActive(true);
        _levelEndScreen.gameObject.SetActive(true);
    }


}
