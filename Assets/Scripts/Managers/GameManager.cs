using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    [HideInInspector] public float score = 0;
    [HideInInspector] public float scoreAct1 = 0;
    [HideInInspector] public float scoreAct2 = 0;
    [SerializeField] private float scoreScaleCombot;
    public int dechetMax;
    [HideInInspector] public int dechetBienTrie;
    public int dechetRestant;
    [HideInInspector] public int chaine;
    [HideInInspector] public int chaineMax;

    [SerializeField] private GameObject[] _preFabRecicl;
    [SerializeField] private GameObject[] _preFabNonRecicl;
    [SerializeField] private GameObject[] _preFabVerre;
    [SerializeField] private string _tagToCheck;
    [SerializeField] private Vector3 _respawnPosition;

    [SerializeField] private Canvas[] CanvasMenu;
    [SerializeField] private GameObject[] CanvasHUD;
    [SerializeField] private UiScore _uiScore;
    [SerializeField] private UiDechetRestant _uiDechetRestant;
    [SerializeField] private float couldownInterDechet;
    private float couldown;


    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start() {
        dechetRestant = dechetMax;
        Time.timeScale = 0;
        RestChaine();
    }

    void Update() {
        score = scoreAct1 + scoreAct2;
        createDechet();
        UpdateUi();
        couldown += Time.deltaTime;
    }

    public void createDechet() {
        if (dechetRestant >= 0) {
            GameObject[] remaining = GameObject.FindGameObjectsWithTag(_tagToCheck);
            if (remaining.Length == 0 || couldown > 5) {
                couldown = 0;
                GameObject instance = Instantiate(ChoosePreFab(), _respawnPosition, ChoosePreFab().transform.rotation);
                Debug.Log("Nouveau " + _tagToCheck + " instancié !");
                dechetRestant -= 1;
            }
        } else {
            Time.timeScale = 0;
            CanvasMenu[1].gameObject.SetActive(true);
            CanvasMenu[1].gameObject.GetComponent<VictoirneScreen>().DisplayFinal(score.ToString(),scoreAct1.ToString(),scoreAct2.ToString(),dechetMax.ToString(), dechetBienTrie.ToString(),chaineMax.ToString());
            foreach (GameObject Hud in CanvasHUD) {
                Hud.SetActive(false);
            }
        }
    }
    public void upTri() {
        dechetBienTrie += 1;
    }

    public void UpScore() {
        scoreAct2 += chaine * scoreScaleCombot + 70;
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

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void StartMiniJeu()
    {
        CanvasMenu[0].gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
