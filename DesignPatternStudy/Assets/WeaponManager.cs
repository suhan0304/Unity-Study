using UnityEngine;

public interface WeaponManager {
    void offensive();
}

public class Sword : Weapon {
    public void offensive() {
        Debug.Log("칼을 휘두르다.");
    }
}

public class Shield : Weapon {
    public void offensive() {
        Debug.Log("방패로 밀치다.");
    }
}

public class Crossbow : Weapon {
    public void offensive() {
        Debug.Log("석궁을 발사하다.");
    }
}