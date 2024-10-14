using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subsystem1 {
    public string operation1() {
        return "Subsystem1 : Ready!\n";
    }

    public string operationN() {
        return "Subsystem1 : Go!\n";
    }
}

public class Subsystem2 {
    public string operation1() {
        return "Subsystem2 : Ready!\n";
    }

    public string operationZ() {
        return "Subsystem1 : Fire!\n";
    }
}

public class Facade {
    protected Subsystem1 _subsystem1;
    protected Subsystem2 _subsystem2;

    public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2) {
        this._subsystem1 = subsystem1;
        this._subsystem2 = subsystem2;
    }

    public string Operation() {
        string result = "Facade initializes subsytstems:";
        result += this._subsystem1.operation1();
        result += this._subsystem2.operation1();
        result += "Facade orders subsystems to perform the action:\n";
        result += this._subsystem1.operationN();
        result += this._subsystem2.operationZ();
        return result;
    }
}

class FacadeClient {
    public static void ClientCode(Facade Facde) {
        Debug.Log(Facde.Operation());
    }

}

public class FacadeSample : MonoBehaviour {
    private void Start() {
        Subsystem1 subsystem1 = new Subsystem1();
        Subsystem2 subsystem2 = new Subsystem2();

        Facade facade = new Facade(subsystem1, subsystem2);
        FacadeClient.ClientCode(facade);
    }
}