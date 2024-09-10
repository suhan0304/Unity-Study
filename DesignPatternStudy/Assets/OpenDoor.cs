using UnityEngine;

public class OpenDoor
{
    public static readonly int OPEN = 0;
    public static readonly int CLOSE = 1;
    public static readonly int LOCK = 2;

    private int DoorState;

    public OpenDoor() {
        this.DoorState = OpenDoor.CLOSE; //닫은 상태로 시작
    }

    public void changeState(int state) { //상태 전환
        this.DoorState = state;
    }

    public void DoorOpenButtonClick() {
        if (DoorState == OPEN) {
            Debug.Log("문 CLOSE");
            changeState(OpenDoor.CLOSE);
        }
        else if (DoorState == CLOSE) {
            Debug.Log("문 OPEN");
            changeState(OpenDoor.OPEN);
        }
        else if (DoorState == LOCK) {
            Debug.Log("문을 열 수 없습니다.");
        }
    }

    public void TryUnlockDoor() { //자물쇠로 문을 따기 (LOCK에서만 동작)
        if (DoorState == OPEN) {
            throw new System.Exception("문이 UNLOCK 된 상태입니다.");
        }
        else if (DoorState == CLOSE) {
            throw new System.Exception("문이 UNLOCK 된 상태입니다.");
        }
        else if (DoorState == LOCK) {
            Debug.Log("문을 땄습니다!");
            changeState(OpenDoor.OPEN);
        }
    }

    public void setLockState() {
        Debug.Log("문을 잠궜습니다.");
        changeState(OpenDoor.LOCK);
    }

    public void PrintCurrentState() {
        if (DoorState == OPEN) {
            Debug.Log("문은 현재 OPEN 상태입니다.");
        }
        else if (DoorState == CLOSE) {
            Debug.Log("문은 현재 CLOSE 상태입니다.");
        }
        else if (DoorState == LOCK) {
            Debug.Log("문은 현재 LOCK 상태입니다.");
        }
    }
}
