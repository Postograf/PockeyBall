using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private float _distanceBetweenCoins;

    public void Spawn(Vector3 spawnStart, int count)
    {
        var spawnPoint = spawnStart;

        for(int i = 0; i < count; i++)
        {
            Instantiate(_coinPrefab, spawnPoint, _coinPrefab.transform.rotation);
            spawnPoint.y += _coinPrefab.transform.localScale.x + _distanceBetweenCoins;
        }
    }
}
