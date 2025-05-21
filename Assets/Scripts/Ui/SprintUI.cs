using UnityEngine;
using UnityEngine.UI;

public class SprintUI : MonoBehaviour
{
    [SerializeField] private Image _sprintBarFill;
    [SerializeField] private Color _readyColor;
    [SerializeField] private Color _rechargingColor;
    private float _currentFill;
    private bool _isSprinting;




    public void UpdateSprintDisplay(float updatedSprintDuration, float baseSprintDuration, float sprintCDValue, float maxsprintCDValue, bool isSprinting)
    {
        if (updatedSprintDuration > 0 && _isSprinting)
        {
            _currentFill = updatedSprintDuration / baseSprintDuration;
        }
        else
        {
            _currentFill = (sprintCDValue - baseSprintDuration) / (maxsprintCDValue - baseSprintDuration);
        }
        _sprintBarFill.fillAmount = _currentFill;
        _isSprinting = isSprinting;
    }

    private void Update()
    {
        if (_isSprinting || _currentFill >= 1)
        {
            _sprintBarFill.color = _readyColor;
        }
        else
        {
            _sprintBarFill.color = _rechargingColor;
        }
    }
}
