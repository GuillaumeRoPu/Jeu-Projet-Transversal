using UnityEngine;

public class ComboMultiplicator : MonoBehaviour
{
    private float _animationSpeed;
    private bool _canAnimate;
    private bool _increase;
    private Vector3 _originalScale;
    private float _timer;

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
            _timer += Time.deltaTime;
            gameObject.transform.localScale = Mathf.Lerp(_originalScale, _originalScale*2, );
        }
        else if (_canAnimate && !_increase)
        {

        }
    }

    public void CoolAnimation(bool increase)
    {
        _increase = increase;
        _canAnimate = true;
    }
}
