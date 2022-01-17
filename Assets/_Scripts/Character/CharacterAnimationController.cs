using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private readonly int _isRunning = Animator.StringToHash("isRunning");
    private readonly int _isDancing = Animator.StringToHash("isDancing");
    private readonly int _isFalling = Animator.StringToHash("isFalling");

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Run();
        }else if (Input.GetKeyDown(KeyCode.W))
        {
            Dance();
        }else if (Input.GetKeyDown(KeyCode.E))
        {
            Fall();
        }
    }

    public void Dance()
    {
        _animator.SetBool(_isDancing,true);
        _animator.SetBool(_isRunning,false);
    }

    public void Fall()
    {
        _animator.SetBool(_isFalling,true);
        _animator.SetBool(_isRunning,false);
    }

    public void Run()
    {
        _animator.SetBool(_isRunning,true);
        _animator.SetBool(_isFalling,false);
        _animator.SetBool(_isDancing,false);
    }
}
