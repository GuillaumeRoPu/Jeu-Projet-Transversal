using UnityEngine;

public class TrashController : MonoBehaviour
{
    [SerializeField] private Acte1Data acte1;
    public int _value { get; private set; }

    public void Delete()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
