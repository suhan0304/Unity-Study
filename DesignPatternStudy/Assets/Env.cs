using UnityEngine;

public class Env : MonoBehaviour
{
    private void Start()
    {
        EnvObjFactoryMethod factory = null;
        Tree tree = null;
        Rock rock = null;
        
        // Forest Tree 생성
        factory = new TreeFactory();
        tree = (Tree)factory.CreateOperation("Forest");
        tree.Create();
        
        // Desert Tree 생성
        factory = new TreeFactory();
        tree = (Tree)factory.CreateOperation("Desert");
        tree.Create();
        
        // Forest Rock 생성
        factory = new RockFactory();
        rock = (Rock)factory.CreateOperation("Forest");
        rock.Create();
        
        // Desert Rock 생성
        factory = new RockFactory();
        rock = (Rock)factory.CreateOperation("Desert");
        rock.Create();
    }
}
