using UnityEngine;

public class PlayerControllerV2 : MonoBehaviour
{
    [SerializeField] private Acte1Data _acte1Data;
    [SerializeField] private ComboUI _comboUI;

    private Transform _transform;
    private Collider2D _collider;
    private Rigidbody2D _rb;

    [Space(5)]
    [Header("Move Stats")]
    [SerializeField] private Vector2 _minMaxPositionBox;
    [SerializeField] private Vector2 _minMaxPositionOffset;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _slowedMoveSpeed;
    private float _updatedMoveSpeed = 3f;
    [SerializeField] private float _sprintMultiplicator = 1;
    private float _updatedSprintMultiplicator = 1;
    private bool _isSprinting;
    [SerializeField] private float _sprintDuration;
    private float _updatedSprintDuration;
    [SerializeField] private float _sprintCD;
    private float _updatedSprintCD;


    [Space(5)]
    [Header("Important stuff")]
    [SerializeField] private ParticleSystem _sprintingParticles;
    [field: SerializeField] public Vector2 _playerPoint { get; private set; }
    

    private bool isFacingRight = true;
    private Vector2 _moveInput;
    private float _direction;

    private float _comboTimer;
    public float _comboValue { get; private set; }

    private bool isInTrigger = false;
    private Collider2D currentCollider;

    [Space(5)]
    [Header("UI")]
    [SerializeField] private GameObject _floatingTextPrefab;
    [SerializeField] private Transform _canvas;


    private void Awake()
    {
        TryGetComponent(out _transform);
        TryGetComponent(out _collider);
        TryGetComponent(out _rb);
        _updatedMoveSpeed = _moveSpeed;
        _updatedSprintCD = 0;
    }

    private void Start()
    {
        _sprintingParticles.Stop();
        _comboValue = 1;
    }

    void Update()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.y = Input.GetAxisRaw("Vertical");
        _moveInput = _moveInput.normalized;
        Flip();
        if (isInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            PickUpTrash(currentCollider);
        }
        Combo();
        Move();
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -_minMaxPositionBox.x/2 + _minMaxPositionOffset.x, _minMaxPositionBox.x/ 2 + _minMaxPositionOffset.x);
        pos.y = Mathf.Clamp(pos.y, -_minMaxPositionBox.y/ 2 + _minMaxPositionOffset.y, _minMaxPositionBox.y/ 2 + _minMaxPositionOffset.y);
        transform.position = pos;
    }

    private void Move()
    {
        Vector2 checkPosition = new Vector2(transform.position.x, transform.position.y) + _playerPoint;
        Collider2D hit = Physics2D.OverlapPoint(checkPosition);
        if (hit.CompareTag("People"))
            _updatedMoveSpeed = _slowedMoveSpeed;
        else
            _updatedMoveSpeed = _moveSpeed;
        SprintCheck();
        _rb.MovePosition(_rb.position + _moveInput * _updatedMoveSpeed * Time.fixedDeltaTime);
    }

    private void SprintCheck()
    {
        _updatedSprintCD += Time.deltaTime;
        _updatedSprintDuration -= Time.deltaTime;
        if(!_isSprinting && Input.GetKeyDown(KeyCode.LeftShift) && _updatedSprintCD >= _sprintCD)
        {
            _updatedSprintCD = 0;
            _isSprinting = true;
            _updatedSprintMultiplicator = _sprintMultiplicator;
            _updatedSprintDuration = _sprintDuration;
            _sprintingParticles.Play(); ;
        }
        if(_updatedSprintDuration >= 0)
        {
            _updatedSprintMultiplicator = _sprintMultiplicator;
        }
        else if(_updatedSprintDuration < 0 && _isSprinting)
        {
            _updatedSprintMultiplicator = 1;
            _isSprinting = false;
            _sprintingParticles.Stop();
        }
        _updatedMoveSpeed *= _updatedSprintMultiplicator;
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
        _acte1Data.trashCollected += 1;
        TrashController trashController = x.gameObject.GetComponent<TrashController>();
        if (trashController == null)
        {
            Debug.LogError("Neuille frr");
        }
        _acte1Data.score += trashController._value * _comboValue * 10;
        ShowPickupText(trashController._value * _comboValue * 10);
        ComboAdd();
        trashController.Delete();
    }

    private void ComboAdd()
    {
        _comboTimer = _acte1Data.comboTimeDecrease;
        _comboValue += _acte1Data.comboAddValue;
        _comboValue = Mathf.Clamp(_comboValue, 1, _acte1Data.maxCombo);
        _comboUI._addTimer = true;
        _comboUI.SetText(true, "x" + _comboValue);
    }

    private void Combo()
    {
        if (_comboValue > 1)
            _comboTimer -= Time.deltaTime;
        if (_comboTimer <= 0 && _comboValue > 1)
        {
            _comboValue -= _acte1Data.comboAddValue;
            _comboValue = Mathf.Clamp(_comboValue, 1, _acte1Data.maxCombo);
            _comboTimer = _acte1Data.comboTimeDecrease;
            _comboUI.SetText(false, "x" + _comboValue);
            if (_comboValue == 1)
            {
                Debug.Log("Lost Combo");
                _comboTimer = 0;
                _comboUI._addTimer = true;
            }
        }
        _comboUI.UpdateComboDisplay(_comboTimer, _acte1Data.comboTimeDecrease);
    }

    void ShowPickupText(float value)
    {
        GameObject textObj = Instantiate(_floatingTextPrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
        textObj.transform.SetParent(_canvas);
        textObj.SetActive(true);
        textObj.GetComponent<FloatingText>().SetText("+ " + value);

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
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(_minMaxPositionOffset, _minMaxPositionBox);
    }
}
