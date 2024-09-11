using UnityEngine;

public class Monster : MonoBehaviour
{
    public int monsterType;
    public string monsterName;
    public int monsterHp;
    public bool monsterAgressive; 

    public string PrintAboutMonster() {
        return string.Format("Monster {{ type: '{0}', name: '{1}', HP: '{2}', agressive: '{3}' }}", monsterType, monsterName, monsterHp, monsterAgressive);
    }
}

public class Goblin : Monster {
    public Goblin() {
        monsterType = 1;
        monsterName = "Goblin";
        monsterHp = 100;
        monsterAgressive = true;
    }
}

public class Slime : Monster {
    public Slime() {
        monsterType = 2;
        monsterName = "Slime";
        monsterHp = 50;
        monsterAgressive = false;
    }
}

public class Skeleton : Monster {
    public Skeleton() {
        monsterType = 3;
        monsterName = "Skeleton";
        monsterHp = 200;
        monsterAgressive = true;
    }
}