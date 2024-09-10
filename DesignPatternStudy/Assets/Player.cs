using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start() {
        OpenDoor door = new OpenDoor();
        door.PrintCurrentState();

        // 문 열기 : CLOSE → OPEN
        door.DoorOpenButtonClick();
        door.PrintCurrentState();

        // 문 잠구기 : OPEN → LOCK
        door.setLockState();
        door.PrintCurrentState();
        door.TryUnlockDoor(); // 문 따기 시도

        // 문 다시 열기 : LOCK → OPEN
        door.DoorOpenButtonClick();
        door.PrintCurrentState();

        // 문 닫기 : OPEN → CLOSE
        door.DoorOpenButtonClick();
        door.PrintCurrentState();
    }
}
