using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    void Start()
    {
        Monster goblin1 = new GoblinFoctory().orderMonster();
        Debug.Log(goblin1);

        Monster slime1 = new SlimeFoctory().orderMonster();
        Debug.Log(slime1);

        Monster skeleton1 = new SkeletonFoctory().orderMonster();
        Debug.Log(skeleton1);
    }
}
