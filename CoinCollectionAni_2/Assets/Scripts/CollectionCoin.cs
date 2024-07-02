using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class CollectionCoin : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform coinParent;
    [SerializeField] private Transform spawnLocation;

    [SerializeField] private int cointAmount;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    void Start()
    {
        CollectionCoins();
    }

    private void CollectionCoins()
    {
        // Spanw some Coins

        for (int i = 0; i < cointAmount; i++)
        {
            GameObject coinInstance = Instantiate(coinPrefab, coinParent);
            float xPosition = spawnLocation.position.x + Random.Range(minX, maxX);
            float yPosition = spawnLocation.position.x + Random.Range(minX, maxX);
            coinInstance.transform.position = new Vector3(xPosition, yPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
