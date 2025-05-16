using UnityEngine;

public class PlayerControllerV2 : MonoBehaviour
{
    [SerializeField] private Acte1Data _acte1Data;

    private Transform _transform;
    private Collider2D _collider;
    private Rigidbody2D _rb;

    [SerializeField] private float _moveSpeed;

    private bool isFacingRight = true;
    private Vector2 _moveInput;
    private float _direction;

    private bool isInTrigger = false;
    private Collider2D currentCollider;


    private void Awake()
    {
        TryGetComponent(out _transform);
        TryGetComponent(out _collider);
        TryGetComponent(out _rb);
    }


    void Update()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.y = Input.GetAxisRaw("Vertical");
        Move();
        Flip();

        if (isInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            PickUpTrash(currentCollider);
        }

    }

    private void Move()
    {
        _rb.linearVelocityX = _moveInput.x*_moveSpeed;
        _rb.linearVelocityY = _moveInput.y*_moveSpeed;
    }

    private void Flip()
    {
        if (isFacingRight && _moveInput.x < 0f || !isFacingRight && _moveInput.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            _direction = _transform.localScale.x;
        }
    }

    private void PickUpTrash(Collider2D x)
    {
        x.SendMessage("Delete");
        _acte1Data.trashCollected += 1;
        Debug.Log(_acte1Data.trashCollected);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            isInTrigger = true;
            currentCollider = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            isInTrigger = false;
            currentCollider = null;
        }
    }

}
