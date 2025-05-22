using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public float score = 0;
    public float scoreAct1 = 0;
    public float scoreAct2 = 0;
    [SerializeField] private float scoreScaleCombot;
    public int dechetMax;
    public int dechetBienTrie;
    public int dechetRestant;
    public int chaine;
    public int chaineMax;

    [SerializeField] private GameObject[] _preFabRecicl;
    [SerializeField] private GameObject[] _preFabNonRecicl;
    [SerializeField] private GameObject[] _preFabVerre;
    [SerializeField] private string _tagToCheck;
    [SerializeField] private Vector3 _respawnPosition;

    [SerializeField] private Canvas[] CanvasMenu;
    [SerializeField] private GameObject[] CanvasHUD;
    [SerializeField] private UiScore _uiScore;
    [SerializeField] private UiDechetRestant _uiDechetRestant;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start() {
        dechetRestant = dechetMax;
        RestChaine();
    }

    void Update() {
        score = scoreAct1 + scoreAct2;
        createDechet();
        UpdateUi();
    }

    public void createDechet() {
        if (dechetRestant > 0) {
            GameObject[] remaining = GameObject.FindGameObjectsWithTag(_tagToCheck);
            if (remaining.Length == 0) {
                GameObject instance = Instantiate(ChoosePreFab(), _respawnPosition, ChoosePreFab().transform.rotation);
                Debug.Log("Nouveau " + _tagToCheck + " instancié !");
                dechetRestant -= 1;
            }
        } else {
            Time.timeScale = 0;
            CanvasMenu[2].gameObject.SetActive(true);
            CanvasMenu[2].gameObject.GetComponent<VictoirneScreen>().DisplayFinal(score.ToString(),scoreAct1.ToString(),scoreAct2.ToString(),dechetMax.ToString(), dechetBienTrie.ToString(),chaineMax.ToString());
            foreach (GameObject Hud in CanvasHUD) {
                Hud.SetActive(false);
            }
        }
    }
    public void upTri() {
        dechetBienTrie += 1;
    }

    public void UpScore() {
        scoreAct2 += chaine * scoreScaleCombot + 5;
    }
    public void UpChaine() {
        chaine += 1;
        if (chaine > chaineMax) {
            chaineMax = chaine;
        }
    }
    public void RestChaine() {
        chaine = 0;
    }

    public void UpdateUi() {
        _uiScore.UpdateDisplayScore(score.ToString());
        _uiDechetRestant.UpdateDisplayDechetRestant(dechetRestant,dechetMax);
    }

    GameObject ChoosePreFab() {
        int _temp = Random.Range(0, 3);
        GameObject pref = null;

        switch (_temp) {
            case 0:
                pref = _preFabRecicl[Random.Range(0, _preFabRecicl.Length)];
                break;
            case 1:
                pref = _preFabNonRecicl[Random.Range(0, _preFabNonRecicl.Length)];
                break;
            case 2:
                pref = _preFabVerre[Random.Range(0, _preFabVerre.Length)];
                break;
        }
        return pref;
    }
}
