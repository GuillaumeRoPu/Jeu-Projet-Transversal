using System;
using UnityEngine;

[Serializable]

public struct TrashData
{
    public string label;

    public enum TYPE
    {
        RECYCLABLE,
        VERRE,
        DECHETPASBO
    }

    [Header("TRASH")]
    [Range(0.1f, 20f)] public float size;
    public Color color;
    public SpriteRenderer sprite;
    public float score;

}
