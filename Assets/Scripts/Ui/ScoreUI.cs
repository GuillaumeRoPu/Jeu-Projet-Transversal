using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Acte1Data _acte1Data;
    [SerializeField] private TextMeshProUGUI _text;

    public void AddTrashAndScore()
    {
        _text.text = "Score : " + _acte1Data.score + "\nDéchets : " + _acte1Data.trashCollected;
    }
}
