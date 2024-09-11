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
