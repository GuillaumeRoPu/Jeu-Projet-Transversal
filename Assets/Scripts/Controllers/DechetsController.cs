using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UIElements;

public class DechetsController : BaseController {

    public TYPE type;
    [SerializeField] private float _speedMove;
    private GameManager _gameManager;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private void Awake() {
        TryGetComponent(out _rigidbody);
        TryGetComponent(out _spriteRenderer);
    }

    private void Start() {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update() {
        Move();
    }

    void Move() {
        transform.position += Vector3.right * Input.GetAxis("Horizontal") * _speedMove * Time.deltaTime;
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("je touche quelque chose");
        if (collision.transform.tag == "Poubelle") {
            Debug.Log("c'est une poubelle");
            if (collision.gameObject.GetComponent<PoubelleController>().type == type) {
                Debug.Log("en plus elle est de mon type");
                _gameManager.score += 5;
            }
            Destroy(gameObject);
        }
    }
}
