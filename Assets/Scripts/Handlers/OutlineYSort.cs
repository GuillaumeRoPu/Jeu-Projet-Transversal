using UnityEngine;

public class OutlineYSort : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _outline;

    void LateUpdate()
    {
        _outline.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100) - 1;
    }
}
