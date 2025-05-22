using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ComboUI : MonoBehaviour
{
    [Header("Combo Bar")]
    [SerializeField] private Image _comboBarFill;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;
    public bool _addTimer;
    private float _timerFade;
    private float _currentFill;

    [Header("Combo Multiplicator")]
    [SerializeField] private ComboMultiplicator _textObject;
    [SerializeField] private TextMeshProUGUI _text;


    private void OnEnable()
    {
        _timerFade = 0f;
        _addTimer = false;
    }

    public void UpdateComboDisplay(float comboCDValue, float maxcomboCDValue)
    {
        _currentFill = comboCDValue/maxcomboCDValue;
        _comboBarFill.fillAmount = _currentFill;
    }

    private void Update()
    {
        _comboBarFill.color = Color.Lerp(_endColor, _startColor, _currentFill);
        FadeCanva(_addTimer);
    }

    public void FadeCanva(bool addTimer)
    {
        _canvasGroup.alpha = Mathf.Lerp(0f, 1, _timerFade);
        if (addTimer)
            _timerFade += Time.deltaTime;
        else
            _timerFade -= Time.deltaTime;
        _timerFade = Mathf.Clamp(_timerFade, 0f, 1f);
    }

    public void SetText(bool increase, string message)
    {
        _textObject.CoolAnimation(increase);
        _text.text = message;
    }
}
