using UnityEngine;

public class createMonster : MonoBehaviour
{
    public static Monster createMob(int type) {
        if (type == 0) {
            throw new System.Exception("Monster Type Error!");  
        }

        // 몬스터 객체 생성
        GameObject monsterObject = new GameObject();
        Monster monster = monsterObject.AddComponent<Monster>();

        // 몬스터 개체 생성 후처리
        monster.monsterType = type;

        if(type == 1) {
            monster.monsterName = "Goblin";
            monster.monsterHp = 100;
            monster.monsterAgressive = true;
        } else if(type == 2) {
            monster.monsterName = "Slime";
            monster.monsterHp = 50;
            monster.monsterAgressive = false;
        } else if(type == 3) {
            monster.monsterName = "Skeleton";
            monster.monsterHp = 200;
            monster.monsterAgressive = true;
        }

        //게임 오브젝트 이름을 몬스터 이름으로 설정
        monsterObject.name = monster.monsterName;

        Debug.Log($"{monster.name} 몬스터가 스폰 되었습니다!");

        return monster;
    } 

    private void Start() {
        mobSpawn();
    }

    private void mobSpawn() {
        Monster goblin1 = createMob(1);
        Debug.Log(goblin1.PrintAboutMonster());
        
        Monster slime1 = createMob(2);
        Debug.Log(slime1.PrintAboutMonster());
    }
}
