using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class CaffeineBeverage {
    public void prepareRecipe() {
        boilWater();
        brew();
        pourInCup();
        if(customerWantsCondiments()) {
            addCondiments();
        }
    }

    protected abstract void brew();

    protected abstract void addCondiments();

    protected virtual bool customerWantsCondiments() {
        return false;
    }

    public void boilWater() {
        Debug.Log("물 끓이는 중");
    }
    
    public void pourInCup() {
        Debug.Log("컵에 따르는 중");
    }
}

class Coffee : CaffeineBeverage {
    protected override void brew() {
        Debug.Log("필터로 커피 우려내는 중");
        
    }

    protected override void addCondiments() {
        Debug.Log("설탕과 우유를 추가하는 중");
    }

    protected override bool customerWantsCondiments() {
        Debug.Log("고객한테 설탕과 우유를 추가할 지 물어보는 중");
        return true;
    }
}

class Tea : CaffeineBeverage {
    protected override void brew() {
        Debug.Log("컵에 따르는 중");

    }

    protected override void addCondiments() {}
}

public class Drink : MonoBehaviour
{
    void Start() {
        CaffeineBeverage coffee = new Coffee();
        coffee.prepareRecipe();

        CaffeineBeverage tea = new Tea();
        tea.prepareRecipe();
    }
}
