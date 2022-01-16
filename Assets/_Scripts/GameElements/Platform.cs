using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Vector3 _target;
    private bool _canMove = true;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private PlatformEntrance _platformEntrance;
    private int _moveDirection;
    public float xPosition = 0;
    public float positiveXEdgePosition = 1.5f;
    public float negativeXEdgePosition = 1.5f;

    public void Init(Vector3 target)
    {
        _platformEntrance.ResetEntrance();
        _rigidbody.isKinematic = false;
        _canMove = true;
        _target = target;
        _target = new Vector3(0, target.y, target.z);
        if (target.x > 0)
            _moveDirection = 1;
        else
            _moveDirection = -1;
    }

    private void FixedUpdate()
    {
        if(!_canMove)
            return;
        _rigidbody.velocity = Vector3.right * speed * _moveDirection;
    }

    public void StopMoving()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = true;
        _canMove = false;
        _moveDirection = 0;
        xPosition = transform.position.x;
        positiveXEdgePosition = xPosition + transform.localScale.x / 2f;
        negativeXEdgePosition = xPosition - transform.localScale.x / 2f;
    }

    public void Trim(Platform previousPlatform)
    {
        float distance = Mathf.Abs(previousPlatform.xPosition - xPosition);
        if (previousPlatform.xPosition > xPosition) // yeni solda
        {
            if (previousPlatform.negativeXEdgePosition < positiveXEdgePosition) // kesilebilir
            {
                float newXScale = Mathf.Abs(positiveXEdgePosition - previousPlatform.negativeXEdgePosition);
                float newXCenter = (positiveXEdgePosition + previousPlatform.negativeXEdgePosition) / 2f;
                transform.localScale = new Vector3(newXScale, transform.localScale.y, transform.localScale.z);
                transform.position = new Vector3(newXCenter, transform.position.y, transform.position.z);
                
            }
            else
            {
                transform.localScale = Vector3.zero;
            }
        }
        else // yeni sagda
        {
            if (previousPlatform.positiveXEdgePosition > negativeXEdgePosition) // kesilebilir
            {
                float newXScale = Mathf.Abs(previousPlatform.positiveXEdgePosition - negativeXEdgePosition);
                float newXCenter = (previousPlatform.positiveXEdgePosition + negativeXEdgePosition) / 2f;
                transform.localScale = new Vector3(newXScale, transform.localScale.y, transform.localScale.z);
                transform.position = new Vector3(newXCenter, transform.position.y, transform.position.z);
            }
            else
            {
                transform.localScale = Vector3.zero;
            }
        }
    }
}