using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrashDatabase", menuName = "Datas/Trash", order = 2)]
public class ZoomDataBase : ScriptableObject
{
    public List<TrashData> datas = new();

    public TrashData GetData(int id, bool random = false)
    {
        if (random)
            id = Random.Range(0, datas.Count);
        else
            id = Mathf.Clamp(id, 0, datas.Count - 1);

        return datas[id];
    }
}
