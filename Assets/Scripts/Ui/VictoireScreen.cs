using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class VictoirneScreen : MonoBehaviour {
    public TMP_Text DisplayScore;


    // Update is called once per frame
     public void DisplayFinal(string scoretotal, string scoreAct1, string scoreAct2, string dechetsRecup, string dechetsTrie, string chaineMax)
    {
        DisplayScore.text = "Score total : " + scoretotal + "\nScore mini jeu 1 : " + scoreAct1 + "\nScore mini jeu 2 : " + scoreAct2 + "\nNombre de déchet récolté : " + dechetsRecup + "\nNombre de déchet bien trié : " + dechetsTrie + "\nChaine de tri la plus grande : " + chaineMax;
    }
}
