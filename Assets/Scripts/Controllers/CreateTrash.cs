using UnityEngine;

public class CreateTrash : MonoBehaviour
{
    [SerializeField] private Vector2 _trashSpawnOrigin;
    [SerializeField] private Vector2 _trashSpawnArea;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _spawnCD;
    private float _lastSpawnTime;



    private void Awake()
    {
        
    }

    private void Start()
    {
        _lastSpawnTime = 0f;
    }

    private void Update()
    {
        if (_lastSpawnTime + _spawnCD < Time.time)
        {
            Debug.Log("CreatedTrash");
            CreatingTrash();
        }
    }

    private void CreatingTrash()
    {
        _lastSpawnTime = Time.time;
        GameObject clone = Instantiate(_prefab, new Vector3(Random.Range(-_trashSpawnArea.x/2, _trashSpawnArea.x/2), Random.Range(-_trashSpawnArea.y/2, _trashSpawnArea.y/2), 0), Quaternion.identity);
        clone.transform.SetParent(transform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_trashSpawnOrigin, _trashSpawnArea);
    }
}
