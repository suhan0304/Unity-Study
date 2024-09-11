using UnityEngine;

public abstract class MonsterFactory
{
    // 객체 생성 전처리 + 후처리 메서드 (상속 불가)
    public Monster orderMonster() {
        // 객체 생성 전처리

        // 객체 생성
        GameObject monsterObject = new GameObject(); //빈 오브젝트
        Monster monster = createMonster(monsterObject); // 몬스터 생성
        monsterObject.name = monster.monsterName; // 게임 오브젝트 이름을 몬스터 이름으로 설정

        // 객체 생성 후처리
        Debug.Log($"{monster.monsterName} 몬스터가 스폰 되었습니다!");
        return monster;
    }

    // 팩토리 메서드
    abstract protected Monster createMonster(GameObject monsterObject);
}

public class GoblinFoctory : MonsterFactory {
    protected override Monster createMonster(GameObject monsterObject) {
        Goblin goblin = monsterObject.AddComponent<Goblin>();
        goblin.Initialize(1, "Goblin", 100, true);
        return goblin;
    }
}

public class SlimeFoctory : MonsterFactory {
    protected override Monster createMonster(GameObject monsterObject) {
        Slime slime = monsterObject.AddComponent<Slime>();
        slime.Initialize(2, "Slime", 50, false);
        return slime;
    }
}

public class SkeletonFoctory : MonsterFactory {
    protected override Monster createMonster(GameObject monsterObject) {
        Skeleton skeleton = monsterObject.AddComponent<Skeleton>();
        skeleton.Initialize(3, "Skeleton", 200, true);
        return skeleton;
    }
}