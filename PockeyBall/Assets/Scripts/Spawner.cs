
using UnityEngine;

public class Spawner : MonoBehaviour
{
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
        }

        BuildObject(currentObject, _finish.gameObject);
    }

    private GameObject BuildObject(GameObject currentObject, GameObject nextObject)
    {
        return Instantiate(
            nextObject,
            GetBuildPoint(currentObject.transform, nextObject.transform),
            Quaternion.identity
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
