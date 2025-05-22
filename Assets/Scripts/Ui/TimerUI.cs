using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private SceneTimer _sceneTimer;
    [SerializeField] private Acte1Data _acte1Data;
    [SerializeField] private Image _timerBarFill;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;

    private void Update()
    {
        _timerBarFill.fillAmount = Mathf.Lerp(1, 0, _sceneTimer.GetElapsedTime() / (_acte1Data.acte1Timer + _acte1Data.tempsDeRepit));
        _timerBarFill.color = Color.Lerp(_startColor, _endColor, _sceneTimer.GetElapsedTime() / (_acte1Data.acte1Timer + _acte1Data.tempsDeRepit));
    }
}
