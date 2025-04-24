using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInputHandler : MonoBehaviour
{
    private PlayerController _mouse;

    public Vector2 WorldPosition { get ; private set; }
    public event Action Clicked;

    private void OnLook(InputValue value)
    {
        WorldPosition = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
    }

    private void Start()
    {
        _mouse = FindFirstObjectByType<PlayerController>();
    }

    //private void Update()
    //{
    //    WorldPosition = _mouse.mousePos;
    //}

    private void OnClick(InputValue _)
    {
        Clicked?.Invoke();
    }
}
