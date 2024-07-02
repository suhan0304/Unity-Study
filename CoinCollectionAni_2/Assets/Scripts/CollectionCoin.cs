using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectionCoin : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform coinParent;
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private Transform endPosition;
    [SerializeField] private TextMeshProUGUI _coinText;

    [SerializeField] private float duration;

    [SerializeField] private int cointAmount;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    List<GameObject> coins = new List<GameObject>();

    private Tween coinReactionTween;
    private int coin = 0;

    void Start()
    {
        SetCoin(0);
    }

    [Button()]
    private async void CollectCoins()
    {
        //0. Reset
        for (int i = 0; i < coins.Count; i++)
        {
            Destroy(coins[i]);
        }
        coins.Clear();

        List<UniTask> spawnCoinTaskList = new List<UniTask>();
        // 1. Spanw the coin to a specific location with random value
        for (int i = 0; i < cointAmount; i++)
        {
            GameObject coinInstance = Instantiate(coinPrefab, coinParent);
            float xPosition = spawnLocation.position.x + Random.Range(minX, maxX);
            float yPosition = spawnLocation.position.x + Random.Range(minX, maxX);

            coinInstance.transform.position = new Vector3(xPosition, yPosition);
            spawnCoinTaskList.Add(coinInstance.transform.DOPunchPosition(new Vector3(0, 30, 0), Random.Range(0, 1f))
                .SetEase(Ease.InOutElastic).ToUniTask());
            coins.Add(coinInstance);
            await UniTask.Delay(TimeSpan.FromSeconds(.01f));
        }

        await UniTask.WhenAll(spawnCoinTaskList);

        // 2. Move all the coins to the coin Image
        await MoveCoinsTask();
    }

    private void SetCoin(int value) {
        coin = value;
        _coinText.text = coin.ToString();
    }

    private async UniTask MoveCoinsTask()
    {
        List<UniTask> moveCoinTask = new List<UniTask>();
        for (int i = 0; i < coins.Count; i++)
        {
            moveCoinTask.Add(MoveCoinsTask(coins[i]));
            await UniTask.Delay(TimeSpan.FromSeconds(.05f));
        }
    }

    private async UniTask MoveCoinsTask(GameObject coinInstance)
    {
        await coinInstance.transform.DOMove(endPosition.position, duration).SetEase(Ease.InBack).ToUniTask();

        GameObject temp = coinInstance;
        coins.Remove(coinInstance);
        Destroy(temp);

        await ReactToCollectionCoin();
        SetCoin(coin + 1);
    }

    private async UniTask ReactToCollectionCoin() {
        if (coinReactionTween == null) {
            coinReactionTween = endPosition.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.1f).SetEase(Ease.InOutElastic);
            await coinReactionTween.ToUniTask();
            coinReactionTween = null;
        }
    }
}
