using UnityEngine;

[CreateAssetMenu(fileName = "Acte1Data", menuName = "Data/Acte1Data")]
public class Acte1Data : ScriptableObject
{
    [Header("Acte1Data")]
    public float acte1Timer;

    [Space(5)]
    [Header("TrashDatas")]
    public int trashBaseValue;
    public float trashSpawnCD;
    public float trashScaledCD;
    [Header("TrashDatasScale")]
    public AnimationCurve trashSpawnCDScale;

    [Space(5)]
    [Header("PeopleDatasTime")]
    public float peopleCanSpawnTimer;
    public float peopleSpawnCD;
    public float peopleScaledCD;
    [Header("PeopleDatasRandomRange")]
    public Vector2 peopleSpeedRange;
    public Vector2 peopleSizeRange;
    [Header("PeopleDatasScale")]
    public AnimationCurve peopleSpawnCDScale;

    [Space(5)]
    [Header("Scores")]
    public int trashCollected;
    public int score;
}
