
using UnityEngine;

[CreateAssetMenu(fileName = "Acte1Data", menuName = "Data/Acte1Data")]
public class Acte1Data : ScriptableObject
{
    public float acte1Timer;
    public float trashSpawnCD;
    public float trashScaledCD;
    public float peopleCanSpawnTimer;
    public float peopleSpawnCD;
    public float peopleScaleCD;
    public Vector2 peopleMinMaxYScale;

    public int trashCollected;
    public int score;
}
