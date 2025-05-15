using TMPro;
using UnityEngine;

public class UiScore : MonoBehaviour {
    private TMP_Text DisplayScore;

    private void Start() {
        DisplayScore = GetComponent<TMP_Text>();
    }

    public void UpdateDisplayScore(string score) {
        DisplayScore.text = score;
    }
}
