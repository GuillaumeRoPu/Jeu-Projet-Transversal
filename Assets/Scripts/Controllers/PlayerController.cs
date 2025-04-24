using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 targetPos;
    private Vector2 mousePos;
    [SerializeField][Range(0.1f,40)] private float moveSpeed;
    public bool _canMove { get; private set; }

    private SpriteRenderer _spriteRend;

    private void Awake()
    {
        TryGetComponent(out _spriteRend);
    }

    void Start()
    {
        _canMove = true;
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MouseMove();
        SwitchMode();
    }

    void MouseMove()
    {
        if (Input.GetMouseButtonDown(0) && _canMove)
        {
            targetPos = new Vector2(mousePos.x, mousePos.y);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed*Time.deltaTime);
    }

    void SwitchMode()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _canMove = !_canMove;
            if (_canMove)
            {
                _spriteRend.color = Color.white;
            }
            else
            {
                _spriteRend.color = Color.red;
            }
        }
    }
}
