using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour
{
    void Start()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOMove(new Vector3(0f, 5f, 0f), 2f));
        seq.Join(transform.DORotate(new Vector3(0f, -180f, 0f), 2f));
        seq.Append(transform.DORotate(new Vector3(0f, 360f, 0f), 2f));
        seq.Insert(4.0f, transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1.0f));
        seq.Prepend(transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 2.0f));
    }
}
