using System;
using UnityEngine;

public class DancingState : IState
{
    private readonly CharacterController _characterController;
    private readonly CharacterAnimationController _animationController;
    private readonly Rigidbody _rigidbody;
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
    
}