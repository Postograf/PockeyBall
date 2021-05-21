
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Coin spawn")]
    [SerializeField] private CoinSpawner _coinSpawner;
    [SerializeField] private Vector3 _coinOffset;
    [SerializeField] private float _coinChance;
    [SerializeField] private int _coinCount;

    [Header("Tower spawn")]
    [SerializeField] private Segment _segmentPrefab;
    [SerializeField] private Block _blockPrefab;
    [SerializeField] private Finish _finish;
    [SerializeField] private int _towerCount;

    void Start()
    {
        BuildTower();
    }

    private void BuildTower()
    {
        var currentObject = gameObject;

        for (int i = 0; i < _towerCount; i++)
        {
            currentObject = BuildObject(currentObject, _segmentPrefab.gameObject);
            currentObject = BuildObject(currentObject, _blockPrefab.gameObject);

            if (_towerCount > i + 1 && Random.Range(0, 100) <= _coinChance)
                _coinSpawner.Spawn(currentObject.transform.position + _coinOffset, _coinCount);
        }

        BuildObject(currentObject, _finish.gameObject);
    }

    private GameObject BuildObject(GameObject currentObject, GameObject nextObject)
    {
        return Instantiate(
            nextObject,
            GetBuildPoint(currentObject.transform, nextObject.transform),
            Quaternion.identity,
            transform
        );
    }

    private Vector3 GetBuildPoint(Transform currentObject, Transform nextObject)
    {
        return new Vector3(
            currentObject.position.x,
            currentObject.position.y + currentObject.localScale.y / 2 + nextObject.localScale.y / 2,
            currentObject.position.z
        );
    }
}
