using UnityEngine;

public class Monster : MonoBehaviour {
    public int monsterType;
    public string monsterName;
    public int monsterHp;
    public bool monsterAgressive; 

    public override string ToString() {
        return string.Format("Monster {{ type: '{0}', name: '{1}', HP: '{2}', agressive: '{3}' }}", monsterType, monsterName, monsterHp, monsterAgressive);
    }

    public void Initialize(int monsterType, string monsterName, int monsterHp, bool monsterAgressive) {
        this.monsterType = monsterType;
        this.monsterName = monsterName;
        this.monsterHp = monsterHp;
        this.monsterAgressive = monsterAgressive;
    }
}

public class Goblin : Monster {
    // Goblin 관련 로직 + 이벤트 관리
}

public class Slime : Monster {
    // Slime 관련 로직 + 이벤트 관리
}

public class Skeleton : Monster {
    // Skeleton 관련 로직 + 이벤트 관리
}

public class Zombie : Monster {
    // Zombie 관련 로직 + 이벤트 관리
}