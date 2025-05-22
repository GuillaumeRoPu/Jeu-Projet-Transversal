
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Acte1Data _acte1Data;

    [SerializeField] private GameObject _mainMenuUI;
    [SerializeField] private GameObject _scoreMenuUI;
    [SerializeField] private TextMeshProUGUI _scoreText;

    void Start()
    {
        Time.timeScale = 0f; // Pause the game
        _scoreMenuUI.SetActive(false);
        _mainMenuUI.SetActive(true);
    }

    public void StartGame()
    {
        _mainMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    private void Update()
    {
        if (_acte1Data.acte1Timer + _acte1Data.tempsDeRepit < Time.time)
            ShowFinalScore();
    }

    private void ShowFinalScore()
    {
        Time.timeScale = 0f;
        _scoreMenuUI.SetActive(true);
        _scoreText.text = "Déchets Récupérés : " + _acte1Data.trashCollected + "\nScore : " + _acte1Data.score;
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
