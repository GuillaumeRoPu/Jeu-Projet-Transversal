using UnityEngine;

public class TrashController : MonoBehaviour
{
    [SerializeField] private Acte1Data _acte1;
    public float _value { get; private set; }
    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;
    private float _timer;

    private void Awake()
    {
        TryGetComponent(out _spriteRenderer);
    }

    private void Start()
    {
        _value = _acte1.trashBaseValue;
        _timer = 0;
        _originalColor = _spriteRenderer.color;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _acte1.timeBeforePointLoss)
        {
            if(_timer > _acte1.timeBeforePointLoss + _acte1.timeBetweenPointLoss + (_acte1.trashBaseValue - _value) && _value > 0)
            {
                Debug.Log(_acte1.timeBeforePointLoss + _acte1.timeBetweenPointLoss + (_acte1.trashBaseValue - _value));
                _value -= (int)_acte1.pointsLost;
                float ratio = _value / _acte1.trashBaseValue;
                _spriteRenderer.color = Color.Lerp(Color.black, _originalColor, ratio);
            }
        }
    }

    public void Delete()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
