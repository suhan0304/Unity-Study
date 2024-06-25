using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour
{
    private Vector3 targetPos = new Vector3(0, 5, 0);
    private Vector3 targetScale = new Vector3(2, 2, 2);
    void Start()
    {
        transform
            .DOScale(1.5f, 2f)      // DO 대상의 변화를 직접 지시
            .SetEase(Ease.InCirc)   // Set 추가 설정
            .OnComplete(() => transform.DOMove(targetPos, 2.0f)); // On 람다를 이용한 콜백 함수
    }
}
