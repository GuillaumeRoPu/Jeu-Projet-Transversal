using UnityEngine;

public class PeopleController : MonoBehaviour
{
    private BoxCollider2D _collider2D;
    private Rigidbody2D _rb;

    public bool _isEnabled = false;
    private Vector2 _boundsLeftRight;
    private Vector2 _limitsLeftRight;
    private bool _goesLeft;

    private float _moveSpeed;

    private void Awake()
    {
        TryGetComponent(out _collider2D);
        TryGetComponent(out _rb);
    }

    private void Update()
    {
        _boundsLeftRight = new Vector2(_collider2D.bounds.min.x, _collider2D.bounds.max.x);
        if (_isEnabled)
        {
            if (_goesLeft)
            {
                //_rb.linearVelocityX = -_moveSpeed;
                if (_boundsLeftRight.y <= _limitsLeftRight.x)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                //_rb.linearVelocityX = _moveSpeed;
                if (_boundsLeftRight.x >= _limitsLeftRight.y)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void DataUpdate(float size, bool goesLeft, float speed, float spawnY, Vector2 limits)
    {
        transform.localScale = new Vector3(size, transform.localScale.y, transform.localScale.z);
        _boundsLeftRight = new Vector2(_collider2D.bounds.min.x, _collider2D.bounds.max.x);
        _limitsLeftRight = limits;
        _moveSpeed = speed;
        _goesLeft = goesLeft;
        if (goesLeft)
        {
            transform.position = new Vector3(_limitsLeftRight.y + _collider2D.size.x/2, spawnY, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(_limitsLeftRight.x - _collider2D.size.x/2, spawnY, transform.position.z);
        }
        _isEnabled = true;
    }
}
