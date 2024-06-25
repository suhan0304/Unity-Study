using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MyText : MonoBehaviour
{
    void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.DOAnchorPosX(0, 5).SetDelay(1.5f).SetEase(Ease.InOutBounce);
    }
}
