using System.Threading;
using UnityEngine;

interface IImage
{
    void ShowItemImage();
}

public class HighResolutionItemImage : IImage
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
            Thread.Sleep((3000));
            img = path;
        }
        catch (ThreadInterruptedException e)
        {
            Debug.Log(e.StackTrace);
        }
        Debug.Log($"{path}에 있는 아이템 이미지 로딩 완료");
    }

    public void ShowItemImage()
    {
        Debug.Log($"{img} 이미지 출력");
    }
}

public class ItemImageProxy : IImage
{
    private IImage proxyImage;
    private string path;

    public ItemImageProxy(string path)
    {
        this.path = path;
    }

    public void ShowItemImage()
    {
        proxyImage = new HighResolutionItemImage(path);
        proxyImage.ShowItemImage();
    }
}
