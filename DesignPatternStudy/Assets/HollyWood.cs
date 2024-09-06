using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Higher {
    public void print(int num) {
        Debug.Log(num);
    }

    public abstract int calculate(int n1, int n2);
}

class LowerA : Higher{
    public override int calculate(int n1, int n2) {
        return n1 + n2;
    }
}

class LowerB : Higher{
    public override int calculate(int n1, int n2) {
        return n1 - n2;
    }
}

public class HollyWood : MonoBehaviour
{
    void Start() {
        Higher obj = new LowerA();

        obj.print(1000);

        Debug.Log(obj.calculate(10, 20));

        obj = new LowerB();

        Debug.Log(obj.calculate(10, 20));
    }
}
