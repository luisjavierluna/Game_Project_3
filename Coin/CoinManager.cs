using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField] Text coinText;
    [SerializeField] int coin;

    private void Start()
    {
        coinText.text = coin.ToString();
    }

    public void AddCoin(int newCoin)
    {
        coin += newCoin;
        coinText.text = coin.ToString();
    }
}
