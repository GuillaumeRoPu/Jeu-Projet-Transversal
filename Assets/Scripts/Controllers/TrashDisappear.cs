using UnityEngine;

public class TrashDisappear : MonoBehaviour
{
    public void Delete()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
