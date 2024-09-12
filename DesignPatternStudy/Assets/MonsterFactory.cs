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

public class GoblinFactory : MonsterFactory {
    // Thread-safe 한 싱글톤 객체화
    private GoblinFactory() {}

    private static class MonsterInstanceHolder {
        public static readonly GoblinFactory INSTANCE = new GoblinFactory();
    }
    public static GoblinFactory getInstance() {
        return MonsterInstanceHolder.INSTANCE;
    }

    protected override Monster createMonster(GameObject monsterObject) {
        Goblin goblin = monsterObject.AddComponent<Goblin>();
        goblin.Initialize(1, "Goblin", 100, true);
        return goblin;
    }
}

public class SlimeFoctory : MonsterFactory {
    // Thread-safe 한 싱글톤 객체화
    private SlimeFoctory() {}

    private static class MonsterInstanceHolder {
        public static readonly SlimeFoctory INSTANCE = new SlimeFoctory();
    }
    public static SlimeFoctory getInstance() {
        return MonsterInstanceHolder.INSTANCE;
    }

    protected override Monster createMonster(GameObject monsterObject) {
        Slime slime = monsterObject.AddComponent<Slime>();
        slime.Initialize(2, "Slime", 50, false);
        return slime;
    }
}

public class SkeletonFoctory : MonsterFactory {
    // Thread-safe 한 싱글톤 객체화
    private SkeletonFoctory() {}

    private static class MonsterInstanceHolder {
        public static readonly SkeletonFoctory INSTANCE = new SkeletonFoctory();
    }
    public static SkeletonFoctory getInstance() {
        return MonsterInstanceHolder.INSTANCE;
    }

    protected override Monster createMonster(GameObject monsterObject) {
        Skeleton skeleton = monsterObject.AddComponent<Skeleton>();
        skeleton.Initialize(3, "Skeleton", 200, true);
        return skeleton;
    }
}

public class ZombieFactory : MonsterFactory {
    protected override Monster createMonster(GameObject monsterObject) {
        Zombie zombie = monsterObject.AddComponent<Zombie>();
        zombie.Initialize(4, "Zombie", 500, true);
        return zombie;
    }
}