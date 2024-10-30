using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Component 인터페이스
interface ItemComponent {
    int getPrice();
    string getName();
}

// Composite 객체
class Bag : ItemComponent {
    // 아이템과 가방을 모두 저장하기 위해 인터페이스 타입 리스트로 관리
    List<ItemComponent> components = new List<ItemComponent>();

    string name;

    public Bag(string name) {
        this.name = name;
    }

    // 리스트에 아이템 & 가방 추가
    public void add(ItemComponent item) {
        components.Add(item);
    }

    // 현재 가방 내용물 반환
    public List<ItemComponent> getComponents() {
        return components;
    }

    public int getPrice() {
        int sum = 0;

        foreach (ItemComponent component in components) {
            // 요소가 Bag이면 알아서 '재귀함수' 동작, item이면 값을 반환 받음
            sum += component.getPrice();
        }

        return sum;
    }

    public string getName() {
        return name;
    }
}

class Item_Composite : ItemComponent {
    string name;
    int price;

    public Item_Composite(string name, int price) {
        this.name = name;
        this.price = price;
    }

    public int getPrice() {
        return price;
    }

    public string getName() {
        return name;
    }
}