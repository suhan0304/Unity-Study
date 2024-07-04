using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class AnimateScene : MonoBehaviour
{
    [SerializeField] private Transform[] outerObjectsTransform;

    async void Start() {
        await AnimateOuterObject(outerObjectsTransform, this.GetCancellationTokenOnDestroy());
    }

    private async UniTask AnimateOuterObject(Transform[] objectsToAnimate, CancellationToken cancelltationToken) 
    {
        await UniTask.Delay(TimeSpan.FromSeconds(0.2f), cancellationToken: cancelltationToken);
        for (int i = 0; i < objectsToAnimate.Length; i++) {
            objectsToAnimate[i].gameObject.SetActive(true);
            objectsToAnimate[i].DOScale(Vector3.zero, 0.5f).From().SetEase(Ease.InOutBack).WithCancellation(cancelltationToken);
            await UniTask.Delay(TimeSpan.FromSeconds(0.1f), cancellationToken: cancelltationToken);
        }
    }
}
