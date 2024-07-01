using System;
using UnityEngine;

public static class GameDataManager
{    
    [SerializeField] private static int plusCoin = 1000;
    [SerializeField] private static int coin = 0;

    public static int Coin
    {
        get { return coin; }
        private set
        {
            coin = value;

            CoinEvents.CoinLabelUpdate?.Invoke(coin);
        }
    }

    public static void AddCoin() {
        Coin += plusCoin;
    }
}
