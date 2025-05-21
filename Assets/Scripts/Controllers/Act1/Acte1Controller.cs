using UnityEngine;

public class Acte1Controller : MonoBehaviour
{
    [SerializeField] private Acte1Data _acte1Data;

    private void Start()
    {
        _acte1Data.score = 0;
        _acte1Data.trashCollected = 0;
    }
}
