
using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static event Action OnTapped;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnTapped?.Invoke();
        }
    }
}
