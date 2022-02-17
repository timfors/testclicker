using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private BoxCollider2D _collider;
    private SpawnerSettings _settings;
    private Vector2 _minVals;
    private Vector2 _maxVals;
    private List<GameObject> _createdObjects = new List<GameObject>();
    private List<Coroutine> _bonusSpawns = new List<Coroutine>();

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        Vector2 colliderExtra = (_collider.size - _collider.offset) / 2;

        _minVals.x = transform.position.x - colliderExtra.x;
        _maxVals.x = transform.position.x + colliderExtra.x;
        _minVals.y = transform.position.y - colliderExtra.y;
        _maxVals.y = transform.position.y + colliderExtra.y;

    }

    private IEnumerator BonusSpawn(int index)
    {
        var (bonusObj, minTime, maxTime, probability) = _settings.ObjectInfo(index);
        while (true)
        {
            var waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            if (Random.Range(0, 1f) <= probability)
                Spawn<BonusObject>(bonusObj).Init(this);
        }
    }

    private T Spawn<T>(T prefab) where T : MonoBehaviour
    {
        T newObj = Instantiate<T>(prefab, transform.parent);

        newObj.transform.position = GetPos();
        _createdObjects.Add(newObj.gameObject);
        return newObj;
    }

    public MainObject InitClicker(MainObject clickerPrefab)
    {
        MainObject clicker = Spawn<MainObject>(clickerPrefab);

        clicker.SetSpawner(this);
        return clicker;
    }

    public Vector2 GetPos()
    {
        Vector2 newPos;

        newPos.x = Random.Range(_minVals.x, _maxVals.x);
        newPos.y = Random.Range(_minVals.y, _maxVals.y);
        return newPos;
    }

    public void StopBonusSpawn()
    {
        foreach (var bonusSpawn in _bonusSpawns)
            if (bonusSpawn != null)
                StopCoroutine(bonusSpawn);
        _bonusSpawns.Clear();
    }

    public void ClearCreated()
    {
        foreach (var obj in _createdObjects)
            Destroy(obj);
        _createdObjects.Clear();
    }

    public void UnregisterCreated(GameObject obj)
    {
        _createdObjects.Remove(obj);
    }

    public void SetSettings(SpawnerSettings settings)
    {
        StopBonusSpawn();
        _settings = settings;
        for (int i = 0; i < _settings.BonusCount; i++)
        {
            var bonusSpawn = StartCoroutine(BonusSpawn(i));
            _bonusSpawns.Add(bonusSpawn);
        }
    }
}
