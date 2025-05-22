using UnityEngine;

public class CreatePeople : MonoBehaviour
{
    [SerializeField] private SceneTimer _sceneTimer;
    [SerializeField] private Acte1Data _acte1Data;

    [SerializeField] private Vector2 _spawnPeopleBox;
    [SerializeField] private Vector2 _spawnPeopleOffset;
    [SerializeField] private GameObject _prefab;
    private float _peopleUpdatedCD;
    
    private float _lastSpawnTime;
    private float _ratio;

    private void Update()
    {
        _ratio = _sceneTimer.GetElapsedTime() / _acte1Data.acte1Timer;
        if (_sceneTimer.GetElapsedTime() < _acte1Data.acte1Timer && _acte1Data.peopleCanSpawnTimer < _sceneTimer.GetElapsedTime())
        {
            if (_lastSpawnTime + _peopleUpdatedCD < _sceneTimer.GetElapsedTime())
            {
                Debug.Log("CreatedTrash");
                CreatingPeople();
            }
            _peopleUpdatedCD = Mathf.Lerp(_acte1Data.peopleSpawnCD, _acte1Data.peopleScaledCD, _acte1Data.peopleSpawnCDScale.Evaluate(_ratio));
        }
    }

    //Creates a prefab people, transfers data to it to influence it's behavior, etc etc
    private void CreatingPeople()
    {
        _lastSpawnTime = _sceneTimer.GetElapsedTime();
        GameObject clone = Instantiate(_prefab, transform.position, Quaternion.identity);
        PeopleController peopleController = clone.GetComponent<PeopleController>();
        clone.gameObject.SetActive(true);
        bool goesLeft = Random.value > 0.5f;
        float speed = Random.Range(_acte1Data.peopleSpeedRange.x, _acte1Data.peopleSpeedRange.y);
        float sizeX = Random.Range(_acte1Data.peopleSizeXRange.x, _acte1Data.peopleSizeXRange.y);
        float sizeY = Random.Range(_acte1Data.peopleSizeYRange.x, _acte1Data .peopleSizeYRange.y);
        float spawnY = Random.Range(-_spawnPeopleBox.y/2 + _spawnPeopleOffset.y, _spawnPeopleBox.y/2 + _spawnPeopleOffset.y);
        Vector2 limitsLeftRight = new Vector2(-_spawnPeopleBox.x/2 + _spawnPeopleOffset.x, _spawnPeopleBox.x/2 + _spawnPeopleOffset.x);
        peopleController.DataUpdate(sizeX, sizeY, goesLeft, speed, spawnY, limitsLeftRight);

        clone.transform.SetParent(transform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_spawnPeopleOffset, _spawnPeopleBox);
    }
}
