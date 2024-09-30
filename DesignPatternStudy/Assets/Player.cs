using System;
using System.Collections.Generic;

// Subject 인터페이스
interface ISubject {
    void RegisterObserver(IObserver observer);  // 구독 추가
    void RemoveObserver(IObserver observer);    // 구독 삭제
    void NotifyObservers();                     // 상태 변경 시 모든 옵저버에게 알림
}

// Observer 인터페이스
interface IObserver {
    void Update(Player player);  // Subject의 상태가 변경되면 갱신
}

// 체력을 관리하는 Player 클래스 (Subject 역할)
class Player : ISubject {
    public int Health { get; private set; }

    private List<IObserver> observers = new List<IObserver>();

    public Player(int health) {
        Health = health;
    }

    public void TakeDamage(int damage) {
        Health -= damage;
        if (Health < 0) Health = 0;
        NotifyObservers();  // 데미지를 입을 때마다 옵저버들에게 알림
    }

    // 구독자 등록
    public void RegisterObserver(IObserver observer) {
        observers.Add(observer);
    }

    // 구독자 제거
    public void RemoveObserver(IObserver observer) {
        observers.Remove(observer);
    }

    // 구독자들에게 상태 알림
    public void NotifyObservers() {
        foreach (IObserver observer in observers) {
            observer.Update(this);  // 옵저버들에게 현재 체력 상태를 전달
        }
    }
}