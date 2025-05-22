using UnityEngine;

public class CreateTrash : MonoBehaviour
{
    [SerializeField] private Acte1Data _acte1Data;

    [SerializeField] private Vector2 _trashSpawnOrigin;
    [SerializeField] private Vector2 _trashSpawnArea;
    [SerializeField] private GameObject _prefab;
    private float _trashUpdatedCD;
    private float _lastSpawnTime;

    private void Start()
    {
        _lastSpawnTime = 0f;
    }

    private void Update()
    {
        if (Time.time < _acte1Data.acte1Timer) 
        {
            if (_lastSpawnTime + _trashUpdatedCD < Time.time)
            {
                Debug.Log("CreatedTrash");
                CreatingTrash();
            }
            _trashUpdatedCD = Mathf.Lerp(_acte1Data.trashSpawnCD, _acte1Data.trashScaledCD, Time.time / _acte1Data.acte1Timer);
        }
    }

    private void CreatingTrash()
    {
        _lastSpawnTime = Time.time;
        GameObject clone = Instantiate(_prefab, new Vector3(Random.Range(-_trashSpawnArea.x/2 + _trashSpawnOrigin.x, _trashSpawnArea.x/ 2 + _trashSpawnOrigin.x), Random.Range(-_trashSpawnArea.y/2 + _trashSpawnOrigin.y, _trashSpawnArea.y/2 + _trashSpawnOrigin.y), 0), Quaternion.identity);
        clone.gameObject.SetActive(true);
        clone.transform.SetParent(transform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_trashSpawnOrigin, _trashSpawnArea);
    }
}
