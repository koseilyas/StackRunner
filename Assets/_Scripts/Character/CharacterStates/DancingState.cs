using System;
using UnityEngine;

public class DancingState : IState
{
    private readonly CharacterController _characterController;
    private readonly CharacterAnimationController _animationController;
    private readonly Rigidbody _rigidbody;
    private float _dancingDuration = 5f;
    private float _elapsedTime;
    private bool _timerActive;
    public static event Action OnStartDancing;

    public DancingState(CharacterController characterController, CharacterAnimationController animationController, Rigidbody rigidbody)
    {
        _characterController = characterController;
        _animationController = animationController;
        _rigidbody = rigidbody;
    }
    public void Enter()
    {
        _rigidbody.velocity = Vector3.zero;
        _animationController.Dance();
        OnStartDancing?.Invoke();
        StartTimer();
    }

    public void UpdateState()
    {

    }

    public void FixedUpdateState()
    {
        
    }

    public void Exit()
    {
        //OnStartRunning?.Invoke();
    }
    
    void StartTimer()
    {
        _timerActive = true;
        _elapsedTime = 0;
    }

    void StopTimer()
    {
        _timerActive = false;
    }
}