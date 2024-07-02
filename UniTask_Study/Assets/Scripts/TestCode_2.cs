using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TestCode_2 : MonoBehaviour
{
    private CancellationTokenSource _source = new CancellationTokenSource();

    private void Start() {
        Wait3Second_2().Forget();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            _source.Cancel();
            Debug.Log("Wait3Second를 중지");
        }
    }

    private async UniTaskVoid Wait3Second_2() {
        await UniTask.Delay(TimeSpan.FromSeconds(3), cancellationToken : _source.Token);
        Debug.Log("3초가 지났습니다.");
    }
}
