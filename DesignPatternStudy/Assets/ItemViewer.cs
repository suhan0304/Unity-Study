using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemViewer : MonoBehaviour
{
    public void Start()
    {
        HighResolutionItemImage itemImage1 = new HighResolutionItemImage("itemImage1_Path");
        HighResolutionItemImage itemImage2 = new HighResolutionItemImage("itemImage2_Path");
        HighResolutionItemImage itemImage3 = new HighResolutionItemImage("itemImage3_Path");
        
        itemImage2.ShowItemIamge();
    }
}
