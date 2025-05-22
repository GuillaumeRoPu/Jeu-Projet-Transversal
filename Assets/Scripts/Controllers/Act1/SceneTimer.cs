using UnityEngine;

public class SceneTimer : MonoBehaviour
{
    private float sceneStartTime;

    void Start()
    {
        sceneStartTime = Time.time;
    }

    public float GetElapsedTime()
    {
        return Time.time - sceneStartTime;
    }
}
