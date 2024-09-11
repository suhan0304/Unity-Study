using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    void Start()
    {
        Monster goblin1 = GoblinFactory.getInstance().orderMonster();
        Debug.Log(goblin1);

        Monster slime1 = SlimeFoctory.getInstance().orderMonster();
        Debug.Log(slime1);

        Monster skeleton1 = SkeletonFoctory.getInstance().orderMonster();
        Debug.Log(skeleton1);
    }
}
