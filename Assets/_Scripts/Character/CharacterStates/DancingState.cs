using UnityEngine;

public class DancingState : IState
{
    private readonly CharacterController _characterController;
    private readonly CharacterAnimationController _animationController;
    private readonly Rigidbody _rigidbody;

    public DancingState(CharacterController characterController, CharacterAnimationController animationController, Rigidbody rigidbody)
    {
        _characterController = characterController;
        _animationController = animationController;
        _rigidbody = rigidbody;
    }
    public void Enter()
    {
        
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