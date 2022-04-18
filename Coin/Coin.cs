using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int value = 1;

    CoinManager manager;

    private void Start()
    {
        manager = FindObjectOfType<CoinManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            manager.AddCoin(value);
            Destroy(gameObject);
        }
    }
}
