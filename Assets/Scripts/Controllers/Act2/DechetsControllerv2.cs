using UnityEngine;

public class DechetsControllerv2 : BaseController {

    public TYPE type;
    private GameManager _gameManager;
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _gravityScale;
    [SerializeField] private float _gravityStart;
    private float _temp;

    private void Awake() {
        TryGetComponent(out _rigidbody);
    }

    private void Start() {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update() {
        UpdateGravity();
    }

    private void UpdateGravity() {
        _rigidbody.gravityScale = _gravityStart + _gravityScale * _gameManager.chaine;
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Poubelle") {
            if (collision.gameObject.GetComponent<PoubelleController>().type == type) {
                _gameManager.UpScore();
                _gameManager.upTri();
                _gameManager.UpChaine();
            } else _gameManager.RestChaine();

            Destroy(gameObject);
        }
    }
}
