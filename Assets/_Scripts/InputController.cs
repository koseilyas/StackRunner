using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static event Action OnTapped;
    public static bool canTakeInput = true;

    private void OnEnable()
    {
        DancingState.OnStartDancing += StopInput;
        FallingState.OnPlayerFall += StopInput;
    }

    private void StopInput()
    {
        canTakeInput = false;
    }

    private void OnDisable()
    {
        DancingState.OnStartDancing -= StopInput;
        FallingState.OnPlayerFall -= StopInput;
    }

    private void Update()
    {
        if(!canTakeInput)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            OnTapped?.Invoke();
            canTakeInput = false;
        }
    }
}
