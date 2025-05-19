using UnityEngine;

public class TrashController : MonoBehaviour
{


    public void Delete()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
