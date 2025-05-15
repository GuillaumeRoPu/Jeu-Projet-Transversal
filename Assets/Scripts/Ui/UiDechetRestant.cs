using TMPro;
using UnityEngine;

public class UiDechetRestant : MonoBehaviour {
    private TMP_Text DisplayDechetRestant;

    private void Start()
    {
        DisplayDechetRestant = GetComponent<TMP_Text>();
    }

    public void UpdateDisplayDechetRestant(string DechetRestant)
    {
        DisplayDechetRestant.text = DechetRestant;
    }
}
