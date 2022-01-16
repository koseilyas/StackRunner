using UnityEngine;

public class Platform : MonoBehaviour
{
    private Vector3 _target;
    private bool _canMove = true;
    [SerializeField] private float speed;
    [SerializeField] private PlatformEntrance _platformEntrance;
    [SerializeField] private Material[] _platformMaterials;
    [SerializeField] private MeshRenderer _renderer;
    private int _moveDirection;

    public void Init(Vector3 target)
    {
        Material mat = _platformMaterials[Random.Range(0, _platformMaterials.Length-1)];
        _renderer.sharedMaterial = mat;
        _platformEntrance.ResetEntrance();
        _canMove = true;
        _target = target;
        _target = new Vector3(0, target.y, target.z);
        if (target.x > 0)
            _moveDirection = 1;
        else
            _moveDirection = -1;
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
            Debug.Log($"perfect{gameObject.name}" );
            transform.position = new Vector3(previousPlatformXPosition, transform.position.y, transform.position.z);
            transform.localScale = transformPrevious.localScale;
        }else if (previousPlatformNegativeXEdgePosition > platformNegativeXEdgePosition)
        {
            if (previousPlatformNegativeXEdgePosition < platformPositiveXEdgePosition)
            {
                float newXScale = Mathf.Abs(platformPositiveXEdgePosition - previousPlatformNegativeXEdgePosition);
                float newXCenter = (platformPositiveXEdgePosition + previousPlatformNegativeXEdgePosition) / 2f;
                transform.localScale = new Vector3(newXScale, transform.localScale.y, transform.localScale.z);
                transform.position = new Vector3(newXCenter, transform.position.y, transform.position.z);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (platformPositiveXEdgePosition > previousPlatformPositiveXEdgePosition)
        {
            if (previousPlatformPositiveXEdgePosition > platformNegativeXEdgePosition)
            {
                float newXScale = Mathf.Abs(previousPlatformPositiveXEdgePosition - platformNegativeXEdgePosition);
                float newXCenter = (previousPlatformPositiveXEdgePosition + platformNegativeXEdgePosition) / 2f;
                transform.localScale = new Vector3(newXScale, transform.localScale.y, transform.localScale.z);
                transform.position = new Vector3(newXCenter, transform.position.y, transform.position.z);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}