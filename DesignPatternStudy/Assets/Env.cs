using UnityEngine;

public class Env : MonoBehaviour
{
    // 추상 팩토리에서 객체를 생성하는 부분 코드는 같기 때문에 따로 메서드로 묶음 분리
    public static Tree CreateTree(EnvObjAbstractFactory fac)
    {
        return fac.CreateTree();
    }
    
    private void Start()
    {
        EnvObjAbstractFactory factory = null;
        
        // Forest Tree 생성
        factory = new ForestFactory();
        Tree forestTree = CreateTree(factory);
        forestTree.Create();
        
        // Desert Tree 생성
        factory = new DesertFactory();
        Tree desertTree = CreateTree(factory);
        desertTree.Create();
    }
}
