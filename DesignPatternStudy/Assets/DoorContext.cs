using UnityEngine;

public class DoorContext
{
    DoorState doorState;

    public DoorContext() {
        this.doorState = CloseState.getInstance();
    }

    public void ChangeState(DoorState state) {
        this.doorState = state;
    }

    public void setLockState() {
        Debug.Log("문을 잠궜습니다.");
        ChangeState(LockState.getInstance());
    }

    public void DoorOpenButtonClick() {
        doorState.DoorOpenButtonClick(this);
    }

    public void TryUnlockDoor() {
        doorState.TryUnlockDoor(this);
    }

    public void PrintCurrentState() {
        Debug.Log(doorState.currentState());
    }
}
