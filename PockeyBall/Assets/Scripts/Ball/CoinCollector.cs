using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int _coinCount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Coin coin))
        {
            _coinCount++;
            Debug.Log(_coinCount);
            Destroy(coin.gameObject);
        }
    }
}
