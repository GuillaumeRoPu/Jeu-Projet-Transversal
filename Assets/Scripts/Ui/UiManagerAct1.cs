
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private SceneTimer _sceneTimer;
    [SerializeField] private Acte1Data _acte1Data;

    [SerializeField] private GameObject _mainMenuUI;
    [SerializeField] private GameObject _scoreMenuUI;
    [SerializeField] private GameObject _tutorialMenuUI;
    [SerializeField] private TextMeshProUGUI _scoreText;

    void OnEnable()
    {
        Time.timeScale = 0f;
        _scoreMenuUI.SetActive(false);
        _tutorialMenuUI.SetActive(false);
        _mainMenuUI.SetActive(true);
        Debug.Log("GameLaunched");
        Debug.Log(_sceneTimer.GetElapsedTime());
    }

    public void EscapeMainMenu()
    {
        _mainMenuUI.SetActive(false);
        _tutorialMenuUI.SetActive(true);
    }

    public void StartGame()
    {
        _tutorialMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (_acte1Data.acte1Timer + _acte1Data.tempsDeRepit < _sceneTimer.GetElapsedTime())
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
        _scoreMenuUI.SetActive(false);
        SceneManager.LoadScene(name);
    }

    public void Quit()
    {
        Debug.Log("Game is quitting...");
        Application.Quit();
    }

}
