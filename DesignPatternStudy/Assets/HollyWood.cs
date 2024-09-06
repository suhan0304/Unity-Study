using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Higher {
    public void print(int num) {
        Debug.Log(num);
    }
}

class LowerA : Higher{
    public int calculate(int n1, int n2) {
        return n1 + n2;
    }
}

class LowerB : Higher{
    public int operate(int n1, int n2) {
        return n1 - n2;
    }
}

public class HollyWood : MonoBehaviour
{
    void Start() {
        Higher obj = new LowerA();

        obj.print(1000);

        ((LowerA)obj).calculate(10, 20);

        obj = new LowerB();

        ((LowerB)obj).operate(10, 20);
    }
}
