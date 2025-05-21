using UnityEngine;

public class platformController : MonoBehaviour
{
    private Quaternion rotation;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector3 _moveDirection;
    [SerializeField] private Vector3 _LimitePatrolMin;
    [SerializeField] private Vector3 _LimitePatrolMax;
    private Vector3 _relativeLimitePatrolMin;
    private Vector3 _relativeLimitePatrolMax;
    private Rigidbody2D _rgbd2D;

    private void Awake() {
        TryGetComponent(out _rgbd2D);
    }

    private void Start() {
        _relativeLimitePatrolMin = transform.TransformPoint(_LimitePatrolMin);
        _relativeLimitePatrolMax = transform.TransformPoint(_LimitePatrolMax);
        _moveDirection = Vector3.right;
        transform.position = new Vector3(0, 0.65f, 0);
        transform.rotation = new Quaternion(0,0,1,1);

    }
    private void Update() {
        rotation = Quaternion.Euler(0f, 0f, - Input.GetAxis("Horizontal") * 10 * _rotationSpeed * Time.deltaTime);
        transform.rotation = rotation * transform.rotation;
        Move();
    }

    private void Move()
    {
        if (_rgbd2D.transform.position.x < _relativeLimitePatrolMin.x) {
            ChangeDirection();
        }
        else if (_rgbd2D.transform.position.x > _relativeLimitePatrolMax.x) {
            ChangeDirection();
        }

        _rgbd2D.transform.position += _moveDirection * Time.deltaTime * _moveSpeed;

    }


    private void ChangeDirection()
    {
        _moveDirection = - _moveDirection;
    }
}
