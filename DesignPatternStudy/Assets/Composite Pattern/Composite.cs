using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Component 인터페이스
public interface ItemComponent {
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



public class Composite : MonoBehaviour {
    public void Start() {
        // 1. 메인 가방 인스턴스 생성
        Bag bag_main = new Bag("메인 가방");

        // 2. 아이템 인스턴스 생성
        Item_Composite armor = new Item_Composite("갑옷", 250);
        Item_Composite sword = new Item_Composite("장검", 500);

        // 3. 메인 가방에는 모험에 필요한 무구 아이템만을 추가
        bag_main.add(armor);
        bag_main.add(sword);

        // 4. 서브 가방 인스턴스 생성
        Bag bag_food = new Bag("음식 가방");

        // 5. 아이템 인스턴스 생성
        Item_Composite apple = new Item_Composite("사과", 290);
        Item_Composite Banana = new Item_Composite("바나나", 160);

        // 6. 서브 가방에 음식 추가
        bag_food.add(apple);
        bag_food.add(Banana);

        // 7. 메인 가방에 서브 가방 추가
        bag_main.add(bag_food);

        //----------------------------------------------------//

        Composite composite = new Composite();

        // 가방 안에 있는 모든 아이템의 값어치 출력 ( 서브 가방에 있는 물건의 값어치 포함 )
        composite.printPrice(bag_main);

        // 가방 안에 있는 모든 아이템의 값어치 출력
        composite.printPrice(bag_food);

    }    
    public void printPrice(ItemComponent bag) {
        int result = bag.getPrice();
        Debug.Log(bag.getName() + "의 아이템 총합 : " + result + " 골드");
    }
}