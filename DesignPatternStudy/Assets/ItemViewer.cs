using UnityEngine;

public class ItemViewer : MonoBehaviour
{
    public void Start()
    {
        IImage itemImage1 = new ItemImageProxy("itemImage1_Path");
        IImage itemImage2 = new ItemImageProxy("itemImage2_Path");
        IImage itemImage3 = new ItemImageProxy("itemImage3_Path");
        
        itemImage2.ShowItemImage();
    }
}
