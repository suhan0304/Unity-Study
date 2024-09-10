using System;
using UnityEngine;

public interface  DoorState
{
    void DoorOpenButtonClick(DoorContext cxt);

    void TryUnlockDoor(DoorContext cxt);

    string currentState();
}

//OPEN State
class OpenState : DoorState {
    private OpenState() {}

    private static class SingleInstanceHolder {
        public static readonly OpenState INSTANCE = new OpenState();
    }
    
    public static OpenState getInstance() {
        return SingleInstanceHolder.INSTANCE;
    }

    public void DoorOpenButtonClick(DoorContext cxt) {
        Debug.Log("문 CLOSE");
        cxt.ChangeState(CloseState.getInstance());

    }

    public void TryUnlockDoor(DoorContext cxt) {
        throw new System.Exception("문이 UNLOCK 된 상태입니다.");
    }

    public String currentState() {
        return "문은 현재 OPEN 상태입니다.";
    }
}

//CLOSE State
class CloseState : DoorState {
    private CloseState() {}

    private static class SingleInstanceHolder {
        public static readonly CloseState INSTANCE = new CloseState();
    }
    
    public static CloseState getInstance() {
        return SingleInstanceHolder.INSTANCE;
    }

    public void DoorOpenButtonClick(DoorContext cxt) {
        Debug.Log("문 OPEN");
        cxt.ChangeState(OpenState.getInstance());
        
    }

    public void TryUnlockDoor(DoorContext cxt) {
        throw new System.Exception("문이 UNLOCK 된 상태입니다.");
    }

    public String currentState() {
        return "문은 현재 CLOSE 상태입니다.";
    }
}

//LOCK State
class LockState : DoorState {
    private LockState() {}

    private static class SingleInstanceHolder {
        public static readonly LockState INSTANCE = new LockState();
    }
    
    public static LockState getInstance() {
        return SingleInstanceHolder.INSTANCE;
    }
    public void DoorOpenButtonClick(DoorContext cxt) {
        Debug.Log("문을 열 수 없습니다.");
    }

    public void TryUnlockDoor(DoorContext cxt) {
        Debug.Log("문을 땄습니다!");
        cxt.ChangeState(OpenState.getInstance());
    }

    public String currentState() {
        return "문은 현재 LOCK 상태입니다.";
    }
}