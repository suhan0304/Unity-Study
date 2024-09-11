using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMonster : MonoBehaviour
{
    public static Monster createMob(int type) {
        if (type == 0) {
            throw new System.Exception("Monster Type Error!");  
        }

        // 몬스터 객체 생성
        Monster monster = new Monster();

        // 몬스터 개체 생성 후처리
        monster.type = type;

        if(type == 1) {
            monster.name = "Goblin";
            monster.hp = 100;
            monster.agressive = true;
        } else if(type == 2) {
            monster.name = "Slime";
            monster.hp = 50;
            monster.agressive = false;
        } else if(type == 3) {
            monster.name = "Skeleton";
            monster.hp = 200;
            monster.agressive = true;
        }

        Debug.Log($"{monster.name} 몬스터가 스폰 되었습니다!");

        return monster;
    } 

    public void main() {
        Monster goblin1 = createMob(1);
        Debug.Log(goblin1.PrintAboutMonster());
        
        Monster slime1 = createMob(2);
        Debug.Log(goblin1.PrintAboutMonster());
    }
}
