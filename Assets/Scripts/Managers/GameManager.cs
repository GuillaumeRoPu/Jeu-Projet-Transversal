using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public int score = 0;
    public int dechetMax;
    public int dechetRestant;
    public int chaine;

    [SerializeField] private GameObject _preFab;
    [SerializeField] private string _tagToCheck;
    [SerializeField] private Vector3 _respawnPosition;

    [SerializeField] private UiScore _uiScore;

    [SerializeField] private UiDechetRestant _uiDechetRestant;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        dechetRestant = dechetMax;
        chaine = 0;
    }

    void Update() {
        createDechet();
        UpdateUi();
    }

    public void createDechet() {
        if (dechetRestant > 0) {
            GameObject[] remaining = GameObject.FindGameObjectsWithTag(_tagToCheck);
            if (remaining.Length == 0) {
                GameObject instance = Instantiate(_preFab, _respawnPosition, _preFab.transform.rotation);
                Debug.Log("Nouveau " + _tagToCheck + " instancié !");
                dechetRestant -= 1;
            }
        }
    }

    public void UpdateUi() {
        _uiScore.UpdateDisplayScore(score.ToString());
        _uiDechetRestant.UpdateDisplayDechetRestant(dechetRestant,dechetMax);
    }
}
