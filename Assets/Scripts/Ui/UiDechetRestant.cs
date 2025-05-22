using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiDechetRestant : MonoBehaviour {
    public Image DisplayDechetRestant;
    public void UpdateDisplayDechetRestant(float DechetRestant, float DechetMax) {
        DisplayDechetRestant.fillAmount = DechetRestant / DechetMax;
    }
}
