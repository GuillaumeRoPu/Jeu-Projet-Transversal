using UnityEngine;

public class PlayerControllerV2 : MonoBehaviour
{
    [SerializeField] private Acte1Data _acte1Data;

    private Transform _transform;
    private Collider2D _collider;
    private Rigidbody2D _rb;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _slowedMoveSpeed;
    private float _updatedMoveSpeed = 3f;
    [SerializeField] private Vector2 _playerPoint;


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
        _updatedMoveSpeed = _moveSpeed;
    }


    void Update()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.y = Input.GetAxisRaw("Vertical");
        Flip();

        if (isInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            PickUpTrash(currentCollider);
        }


        Vector2 checkPosition = new Vector2(transform.position.x, transform.position.y) + _playerPoint;
        Collider2D hit = Physics2D.OverlapPoint(checkPosition);

        if (hit.CompareTag("People"))
        {
            _updatedMoveSpeed = _slowedMoveSpeed;
            Move();
        }
        else
        {
            _updatedMoveSpeed = _moveSpeed;
            Move();
        }

    }

    private void Move()
    {
        _rb.linearVelocityX = _moveInput.x* _updatedMoveSpeed;
        _rb.linearVelocityY = _moveInput.y* _updatedMoveSpeed;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y) + _playerPoint, 0.5f);
    }
}
