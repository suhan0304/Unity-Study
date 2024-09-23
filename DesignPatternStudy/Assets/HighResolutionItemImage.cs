using System.Threading;
using UnityEngine;

public class HighResolutionItemImage
{
    string img;

    public HighResolutionItemImage(string path)
    {
        LoadItemImage(path);
    }

    private void LoadItemImage(string path)
    {
        try
        {
            Thread.Sleep((1000));
            img = path;
        }
        catch (ThreadInterruptedException e)
        {
            Debug.Log(e.StackTrace);
        }
    }

    public void ShowItemIamge()
    {
        Debug.Log($"{img} 이미지 출력");
    }
}
