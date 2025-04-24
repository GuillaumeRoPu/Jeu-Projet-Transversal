using UnityEngine;
using UnityEngine.Events;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _clicked;

    private BoxCollider2D _collider;
    private MouseInputHandler _mouse;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _mouse = FindFirstObjectByType<MouseInputHandler>();
        _mouse.Clicked += MouseOnClicked;
    }

    private void MouseOnClicked()
    {
        if (_collider.bounds.Contains(_mouse.WorldPosition))
        {
            _clicked?.Invoke();
        }
        Debug.Log("Bounds : " + _collider.bounds + " MousePos : " + _mouse.WorldPosition);
        Debug.Log("Clicked");
    }
}
