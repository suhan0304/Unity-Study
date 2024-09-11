using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    void Start()
    {
        MonsterFactory factory = new MonsterFactory();

        Monster goblin1 = factory.orderMonster(1);
        Debug.Log(goblin1.PrintAboutMonster());

        Monster slime1 = factory.orderMonster(2);
        Debug.Log(slime1.PrintAboutMonster());

        Monster skeleton1 = factory.orderMonster(3);
        Debug.Log(skeleton1.PrintAboutMonster());
    }
}
