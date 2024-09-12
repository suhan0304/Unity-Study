using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    void Start()
    {
        Monster zombie1 = new ZombieFactory().orderMonster();
        Debug.Log(zombie1);
    }
}
