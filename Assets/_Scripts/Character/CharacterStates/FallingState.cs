using System;
using UnityEngine;

public class FallingState : IState
{
    private readonly CharacterController _characterController;
    private readonly CharacterAnimationController _animationController;
    private readonly Rigidbody _rigidbody;
    public static event Action OnPlayerFall;

    public FallingState(CharacterController characterController, CharacterAnimationController animationController, Rigidbody rigidbody)
    {
        _characterController = characterController;
        _animationController = animationController;
        _rigidbody = rigidbody;
    }
    public void Enter()
    {
        _animationController.Fall();
        OnPlayerFall?.Invoke();
    }

    public void UpdateState()
    {
        
    }

    public void FixedUpdateState()
    {
        
    }

    public void Exit()
    {
        
    }
}