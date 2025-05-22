using UnityEngine;

public class ComboMultiplicator : MonoBehaviour
{
    private float _animationSpeed;
    private bool _canAnimate;
    private bool _increase;
    private Vector3 _originalScale;
    private float _timer;
    private bool _reverse;

    private void Start()
    {
        _animationSpeed = 0.2f;
        _timer = 0f;
        _originalScale = gameObject.transform.localScale;
    }

    private void Update()
    {
        if (_canAnimate && _increase)
        {
            if (!_reverse)
            {
                _timer += Time.deltaTime;
                _timer = Mathf.Clamp(_timer, 0f, _animationSpeed);
                gameObject.transform.localScale = new Vector3(Mathf.Lerp(_originalScale.x, _originalScale.x * 2, _timer / _animationSpeed), Mathf.Lerp(_originalScale.y, _originalScale.y * 2, _timer / _animationSpeed), Mathf.Lerp(_originalScale.z, _originalScale.z * 2, _timer / _animationSpeed));
            }
            else
            {
                _timer -= Time.deltaTime;
                _timer = Mathf.Clamp(_timer, 0f, _animationSpeed);
                gameObject.transform.localScale = new Vector3(Mathf.Lerp(_originalScale.x, _originalScale.x * 2, _timer / _animationSpeed), Mathf.Lerp(_originalScale.y, _originalScale.y * 2, _timer / _animationSpeed), Mathf.Lerp(_originalScale.z, _originalScale.z * 2, _timer / _animationSpeed));
            }
            if (_timer >= _animationSpeed)
                _reverse = true;
            if (_timer == 0f && _reverse)
            {
                _reverse = false;
                _canAnimate = false;
            }
        }
        else if (_canAnimate && !_increase)
        {
            if (!_reverse)
            {
                _timer += Time.deltaTime;
                _timer = Mathf.Clamp(_timer, 0f, _animationSpeed);
                gameObject.transform.localScale = new Vector3(Mathf.Lerp(_originalScale.x, _originalScale.x * 0.5f, _timer / _animationSpeed), Mathf.Lerp(_originalScale.y, _originalScale.y * 0.5f, _timer / _animationSpeed), Mathf.Lerp(_originalScale.z, _originalScale.z * 0.5f, _timer / _animationSpeed));
            }
            else
            {
                _timer -= Time.deltaTime;
                _timer = Mathf.Clamp(_timer, 0f, _animationSpeed);
                gameObject.transform.localScale = new Vector3(Mathf.Lerp(_originalScale.x, _originalScale.x * 0.5f, _timer / _animationSpeed), Mathf.Lerp(_originalScale.y, _originalScale.y * 0.5f, _timer / _animationSpeed), Mathf.Lerp(_originalScale.z, _originalScale.z * 0.5f, _timer / _animationSpeed));
            }
            if (_timer >= _animationSpeed)
                _reverse = true;
            if (_timer == 0f && _reverse)
            {
                _reverse = false;
                _canAnimate = false;
            }
        }
    }

    public void CoolAnimation(bool increase)
    {
        Debug.Log("Sent Message");
        _timer = 0f;
        _increase = increase;
        _canAnimate = true;
        _reverse = false;
    }
}
