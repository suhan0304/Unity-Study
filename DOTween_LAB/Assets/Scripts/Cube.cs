using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour
{
    void Start()
    {
        transform.DOMove(Vector3.up * 3, 5f);
        transform.DOScale(Vector3.one * 3, 5f);
        transform.DORotate(Vector3.forward * 3, 5);

        Material mat = GetComponent<MeshRenderer>().material;
        mat.DOColor(Color.cyan, 5);
    }
}
