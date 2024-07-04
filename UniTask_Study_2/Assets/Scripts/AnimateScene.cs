using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AnimateScene : MonoBehaviour
{
    
    [SerializeField] private Transform[] outerObjectsTransform;
    [SerializeField] private Transform[] innerObjectsTransform;
    [SerializeField] private Transform shipTransform;
    [SerializeField] private Transform startPosition;

    private Vector3 currentShipPosition;

    async void Start() {
        CancellationToken cancellationTokenOnDestroy = this.GetCancellationTokenOnDestroy();
        await AnimateOuterObject(outerObjectsTransform, cancellationTokenOnDestroy);
        await AnimateInnerObject(innerObjectsTransform, cancellationTokenOnDestroy);
        await AnimateShip(shipTransform, cancellationTokenOnDestroy);
    }

    private async UniTask AnimateOuterObject(Transform[] objectsToAnimate, CancellationToken cancelltationToken) 
    {
        await UniTask.Delay(TimeSpan.FromSeconds(0.2f), cancellationToken: cancelltationToken);

        UniTask[] tasks = new UniTask[objectsToAnimate.Length];
        for (int i = 0; i < objectsToAnimate.Length; i++)
        {
            tasks[i] = AnimateDelay(objectsToAnimate, i, cancelltationToken, i * 0.1f, i == objectsToAnimate.Length - 1);
        }
        await UniTask.WhenAll(tasks);
    }

    private async UniTask AnimateDelay(Transform[] objectsToAnimate, int i, CancellationToken cancellationToken, float time, bool lastObject)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(time), cancellationToken: cancellationToken);
        objectsToAnimate[i].gameObject.SetActive(true);
        if (lastObject) {
            await objectsToAnimate[i].DOScale(Vector3.zero, 0.5f).From().SetEase(Ease.InOutBack).WithCancellation(cancellationToken);
        }
        else {
            objectsToAnimate[i].DOScale(Vector3.zero, 0.5f).From().SetEase(Ease.InOutBack).WithCancellation(cancellationToken);
        }
    }

    private async UniTask AnimateInnerObject(Transform[] objectsToAnimate, CancellationToken cancellationToken) 
    {
        for (int i = 0; i < objectsToAnimate.Length; i++) 
        {
            objectsToAnimate[i].gameObject.SetActive(true);
            innerObjectsTransform[i].DOScale(Vector3.zero, 0.5f).From().SetEase(Ease.OutBack).WithCancellation(cancellationToken);
        }
    }

    private async UniTask AnimateShip(Transform ship, CancellationToken cancellationToken) {
        currentShipPosition = ship.position;
        ship.position = startPosition.position;
        ship.gameObject.SetActive(true);
        await ship.DOScale(Vector3.zero, 0.5f).From().SetEase(Ease.OutBack).WithCancellation(cancellationToken);
        await ship.DOMove(currentShipPosition, 0.7f).SetEase(Ease.OutBack).WithCancellation(cancellationToken);
    }
}
