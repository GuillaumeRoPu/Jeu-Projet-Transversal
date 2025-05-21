using UnityEngine;

public class DechetsController : BaseController {

    public TYPE type;
    private GameManager _gameManager;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _gravityScale;
    [SerializeField] private float _gravityStart;
    private float _temp;

    private void Awake() {
        TryGetComponent(out _rigidbody);
        TryGetComponent(out _spriteRenderer);
    }

    private void Start() {
        Init();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update() {
        InCam();
        UpdateGravity();
    }

    private void Init() {
        _temp = Random.Range(0, 3);

        switch (_temp) {
            case 0:
                _spriteRenderer.color = Color.yellow;
                type = TYPE.RECYCLABLE;
                break;
            case 1:
                _spriteRenderer.color = Color.green;
                type = TYPE.VERRE;
                break;
            case 2:
                _spriteRenderer.color = Color.black;
                type = TYPE.NONRECYCLABLE;
                break;
        }
    }

    private void UpdateGravity() {
        _rigidbody.gravityScale = _gravityStart + _gravityScale * _gameManager.chaine;
    }

    void InCam() {
        if (transform.position.y < -6 || transform.position.x < -10 || transform.position.x > 10) {
            _gameManager.chaine = 1;
            Destroy(gameObject);
        }

    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Poubelle") {
            if (collision.gameObject.GetComponent<PoubelleController>().type == type) {
                _gameManager.score += 5;
                _gameManager.chaine += 1;
            } else _gameManager.chaine = 1;


            Destroy(gameObject);
        }
    }
}
