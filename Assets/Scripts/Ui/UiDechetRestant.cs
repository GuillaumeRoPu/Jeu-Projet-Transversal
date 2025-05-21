using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiDechetRestant : MonoBehaviour {
    private Slider DisplayDechetRestant;

    private void Start() {
        DisplayDechetRestant = GetComponent<Slider>();
    }

    public void UpdateDisplayDechetRestant(float DechetRestant, float DechetMax) {
        DisplayDechetRestant.value = DechetRestant / DechetMax;
    }
}
