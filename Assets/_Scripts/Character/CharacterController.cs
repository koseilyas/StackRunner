using UnityEngine;

public class CharacterController : StateMachineParent
{
    public RunningState runningState { get; private set; }
    public DancingState dancingState { get; private set; }
    public FallingState fallingState { get; private set; }
    [SerializeField] private CharacterAnimationController _animationController;
    [SerializeField] private Rigidbody _rigidbody;

    private void Awake()
    {
        runningState = new RunningState(this,_animationController,_rigidbody);
        dancingState = new DancingState(this,_animationController,_rigidbody);
        fallingState = new FallingState(this,_animationController,_rigidbody);
    }

    private void Start()
    {
        ChangeState(runningState);
    }

    private void OnEnable()
    {
        PlatformFinish.OnPlayerEnteredFinishingPlatform += PlayerFinish;
    }

    private void OnDisable()
    {
        PlatformFinish.OnPlayerEnteredFinishingPlatform += PlayerFinish;
    }
    
    private void PlayerFinish(Platform obj)
    {
        ChangeState(dancingState);
    }
}