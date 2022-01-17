using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Platform : MonoBehaviour
{
    private Vector3 _target;
    private bool _canMove = true;
    [SerializeField] private float speed;
    [SerializeField] public PlatformEntrance platformEntrance;
    [SerializeField] private Material[] _platformMaterials;
    [SerializeField] private Material _finishingMat;
    [SerializeField] private MeshRenderer _renderer;
    private int _moveDirection;
    public static event Action<int> OnPerfectMatch;
    private static int _streak;

    public void Init(Vector3 target)
    {
        Material mat = _platformMaterials[Random.Range(0, _platformMaterials.Length-1)];
        _renderer.sharedMaterial = mat;
        platformEntrance.Init();
        _canMove = true;
        _target = target;
        _target = new Vector3(0, target.y, target.z);
        if (target.x > 0)
            _moveDirection = 1;
        else if(target.x < 0)
            _moveDirection = -1;
        else
            _renderer.sharedMaterial = _finishingMat;
    }

    private void Update()
    {
        if(!_canMove)
            return;
        transform.Translate(Vector3.right * speed * _moveDirection * Time.deltaTime);
    }

    public void StopMoving()
    {
        _canMove = false;
        _moveDirection = 0;
    }

    /// <summary>
    /// This function is messy.
    /// It calculates and trims new platform.
    /// </summary>
    public void Trim(Platform previousPlatform)
    {
        Transform transformPrevious = previousPlatform.transform;
        float previousPlatformXPosition = transformPrevious.position.x;
        float previousPlatformPositiveXEdgePosition = previousPlatformXPosition + (transformPrevious.localScale.x / 2);
        float previousPlatformNegativeXEdgePosition = previousPlatformXPosition - (transformPrevious.localScale.x / 2);
        
        float platformXPosition = transform.position.x;
        float platformPositiveXEdgePosition = platformXPosition + (transform.localScale.x / 2);
        float platformNegativeXEdgePosition = platformXPosition - (transform.localScale.x / 2);
        
        float distance = Mathf.Abs(previousPlatformXPosition - platformXPosition);
        if (distance < 0.2f)
        {
            OnPerfectMatch?.Invoke(_streak);
            _streak++;
            Debug.Log($"perfect{gameObject.name} streak {_streak}" );
            transform.position = new Vector3(previousPlatformXPosition, transform.position.y, transform.position.z);
            transform.localScale = new Vector3(transformPrevious.localScale.x, transform.localScale.y, transform.localScale.z);
        }else if (previousPlatformNegativeXEdgePosition > platformNegativeXEdgePosition)
        {
            _streak = 0;
            if (previousPlatformNegativeXEdgePosition < platformPositiveXEdgePosition)
            {
                CubeSlicer.Slice(transform, new Vector3(previousPlatformNegativeXEdgePosition, transform.position.y, transform.position.z), true);
            }
            else
            {
                Destroy(gameObject);
            }
            Debug.Log($"not streak 1" );
        }
        else if (platformPositiveXEdgePosition > previousPlatformPositiveXEdgePosition)
        {
            _streak = 0;
            if (previousPlatformPositiveXEdgePosition > platformNegativeXEdgePosition)
            {
                CubeSlicer.Slice(transform, new Vector3(previousPlatformPositiveXEdgePosition, transform.position.y, transform.position.z), false);
            }
            else
            {
                Destroy(gameObject);
            }
            Debug.Log($"not streak 2" );
        }
    }
}