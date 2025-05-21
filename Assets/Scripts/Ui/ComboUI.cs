using UnityEngine;
using UnityEngine.UI;

public class ComboUI : MonoBehaviour
{
    [Header("Combo Bar")]
    [SerializeField] Image ComboBarFill;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;
    private float _time;
    private float _currentFill;



    public void UpdateComboDisplay(float comboCDValue, float maxcomboCDValue)
    {
        _currentFill = comboCDValue/maxcomboCDValue;
        ComboBarFill.fillAmount = _currentFill;
    }

    private void Update()
    {
        ComboBarFill.color = Color.Lerp(_startColor, _endColor, _currentFill);
    }
}
