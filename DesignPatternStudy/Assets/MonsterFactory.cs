using UnityEngine;

public class MonsterFactory
{
    public Monster orderMonster(int type) {
        validate(type);
    
        GameObject monsterObject = new GameObject(); //빈 오브젝트

        Monster monster = createMonster(type, monsterObject); // 몬스터 생성
        
        monsterObject.name = monster.monsterName; // 게임 오브젝트 이름을 몬스터 이름으로 설정

        return monster;
    }

    private Monster createMonster(int type, GameObject monsterObject) {
        Monster monster = null;
        if (type == 1) {
            monster = monsterObject.AddComponent<Goblin>();
            //monster = new Goblin();
        } else if (type == 2) {
            monster = monsterObject.AddComponent<Slime>();
            //monster = new Slime();
        } else if (type == 3) {
            monster = monsterObject.AddComponent<Skeleton>();
            //monster = new Skeleton();
        }

        Debug.Log($"{monster.monsterName} 몬스터가 스폰 되었습니다!");
        
        return monster;
    }

    private void validate(int type) { // 유효성 검사
        if (type == 0) {
            throw new System.Exception("Monster Type Error!"); 
        }
    }
}
