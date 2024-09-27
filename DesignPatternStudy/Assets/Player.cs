using UnityEngine;

public class Player : MonoBehaviour
{
    void Start() {
        // 1. 개머리판을 장착하고 스코프를 달은 총
        Weapon buttstock_scoped_rifle = new Buttstock(new Scoped(new BaseWeapon()));
        buttstock_scoped_rifle.aim_and_fire();
        
        Debug.Log("-------------");

        // 2. 개머리판을 장착하고 스코프를 달은 총
        Weapon scoped_buttstock_rifle = new Scoped(new Buttstock(new BaseWeapon()));
        scoped_buttstock_rifle.aim_and_fire();
    }
}