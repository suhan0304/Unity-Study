using UnityEngine;

public class Player : MonoBehaviour
{
    void Start() {
        // 1. 유탄 발사기가 달린 총
        Weapon generade_rifle = new Generade(new BaseWeapon());
        generade_rifle.aim_and_fire();
        
        // 2. 개머리판을 장착하고 스코프를 달은 총
        Weapon buttstock_scoped_rifle = new Buttstock(new Generade(new BaseWeapon()));
        buttstock_scoped_rifle.aim_and_fire();
        
        // 3. 유탄 발사기 + 개머리판 + 스코프가 달린 총
        Weapon buttstock_scoped_generade_rifle = new Buttstock(new Scoped(new Generade(new BaseWeapon())));
        buttstock_scoped_generade_rifle.aim_and_fire();

    }
}
