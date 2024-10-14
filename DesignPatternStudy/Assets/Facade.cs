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
}