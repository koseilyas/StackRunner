
using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static event Action OnTapped;
    private bool _canTakeInput = true;

    private void OnEnable()
    {
        DancingState.OnStartDancing += StopInput;
    }

    private void StopInput()
    {
        _canTakeInput = false;
    }

    private void OnDisable()
    {
        DancingState.OnStartDancing -= StopInput;
    }

    private void Update()
    {
        if(!_canTakeInput)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            OnTapped?.Invoke();
        }
    }
}
