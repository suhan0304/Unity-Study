using UnityEngine;

public class Player : MonoBehaviour
{
    void Start() {
        DoorContext door = new DoorContext();        
        door.PrintCurrentState();

        // 문 열기 : CLOSE → OPEN
        door.DoorOpenButtonClick();
        door.PrintCurrentState();

        // 문 잠구기 : OPEN → LOCK
        door.setLockState();
        door.PrintCurrentState();
        door.TryUnlockDoor(); // 문 따기 시도
        door.PrintCurrentState();

        // 문 다시 열기 : LOCK → OPEN
        door.DoorOpenButtonClick();
        door.PrintCurrentState();

        // 문 닫기 : OPEN → CLOSE
        door.DoorOpenButtonClick();
        door.PrintCurrentState();
    }
}
