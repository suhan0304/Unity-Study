using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class MyText : MonoBehaviour
{
    void Start()
    {
        //RectTransform rt = GetComponent<RectTransform>();
        //rt.DOAnchorPosX(0, 5).SetDelay(1.5f).SetEase(Ease.InOutBounce);
        
        TMP_Text tmp_text = GetComponent<TMP_Text>();
        tmp_text.DOText("DOTween Example", 2, true, ScrambleMode.All).SetDelay(2);
    }
}
