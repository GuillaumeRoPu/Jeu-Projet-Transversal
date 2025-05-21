
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject _mainMenuUI;
    [SerializeField] GameObject _scoreMenuUI;

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

    public void ShowFinalScore()
    {
        Time.timeScale = 0f;
        _scoreMenuUI.SetActive(true);
    }
}
