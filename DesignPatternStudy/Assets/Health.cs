using UnityEngine;

// 체력 UI를 표시하는 클래스 (Observer 역할)
class HealthUI : IObserver {
    private string UIName;

    public HealthUI(string name) {
        this.UIName = name;
    }

    // Subject의 상태 변경 시 호출되는 메서드
    public void Update(Player player) {
        Debug.Log($"{UIName}'s health: {player.Health}");
    }
}