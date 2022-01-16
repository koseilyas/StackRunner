using UnityEngine;

public class RunningState : IState
{
    private readonly CharacterController _characterController;
    private readonly CharacterAnimationController _animationController;
    private readonly Rigidbody _rigidbody;
    private Vector3 _velocity = new Vector3(0, 0, 2.5f);

    public RunningState(CharacterController characterController, CharacterAnimationController animationController, Rigidbody rigidbody)
    {
        _characterController = characterController;
        _animationController = animationController;
        _rigidbody = rigidbody;
    }

    public void Enter()
    {
        _animationController.Run();
    }

    public void UpdateState()
    {
        
    }

    public void FixedUpdateState()
    {
        _rigidbody.velocity = _velocity;
        if(_rigidbody.transform.position.y < -0.1f)
            _characterController.ChangeState(_characterController.fallingState);
    }

    public void Exit()
    {
        
    }
}