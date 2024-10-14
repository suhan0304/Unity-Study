using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subsystem1 {
    public string operation1() {
        return "Subsystem1 : Ready!";
    }

    public string operatioN() {
        return "Subsystem1 : Go!"
    }
}

public class Facade {
    protected Subsystem1 _subsystem1;
    protected Subsystem2 _subsystem2;
}