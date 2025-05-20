using System;
using UnityEngine;

public class PeopleController : MonoBehaviour
{
    [SerializeField] private PlayerControllerV2 _playerController;

    private BoxCollider2D _collider2D;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;

    [NonSerialized] public bool _isEnabled = false;
    private Vector2 _boundsLeftRight;
    private Vector2 _limitsLeftRight;
    private bool _goesLeft;

    private float _moveSpeed;

    private void Awake()
    {
        TryGetComponent(out _collider2D);
        TryGetComponent(out _rb);
        TryGetComponent(out _spriteRenderer);
    }

    private void Update()
    {
        _boundsLeftRight = new Vector2(_collider2D.bounds.min.x, _collider2D.bounds.max.x);
        if (_isEnabled)
        {
            if (_goesLeft)
            {
                _rb.linearVelocityX = -_moveSpeed;
                if (_boundsLeftRight.y <= _limitsLeftRight.x)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                _rb.linearVelocityX = _moveSpeed;
                if (_boundsLeftRight.x >= _limitsLeftRight.y)
                {
                    Destroy(gameObject);
                }
            }
        }
        if(_collider2D.bounds.Contains(new Vector2(_playerController.gameObject.transform.position.x, _playerController.gameObject.transform.position.y) + _playerController._playerPoint))
        {
            _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 0.5f);
            Debug.Log("Alpha changed");
        }
        else
        {
            _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 1f);
        }
    }

    public void DataUpdate(float sizeX, float sizeY, bool goesLeft, float speed, float spawnY, Vector2 limits)
    {
        transform.localScale = new Vector3(sizeX, sizeY, transform.localScale.z);
        _boundsLeftRight = new Vector2(_collider2D.bounds.min.x, _collider2D.bounds.max.x);
        _limitsLeftRight = limits;
        _moveSpeed = speed;
        _goesLeft = goesLeft;
        if (goesLeft)
        {
            transform.position = new Vector3(_limitsLeftRight.y + transform.position.x - _spriteRenderer.bounds.min.x, spawnY, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(_limitsLeftRight.x + transform.position.x - _spriteRenderer.bounds.max.x, spawnY, transform.position.z);
        }
        _isEnabled = true;
    }
}
