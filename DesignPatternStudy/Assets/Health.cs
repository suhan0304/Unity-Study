using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IUI {
    void Display();
}

class HealthUI : IUI {
    Player player;
    string playerName;

    public HealthUI(string name, Player player) {
        this.playerName = name;
        this.player = player;
    }

    public void Display() {
       Debug.Log($"{playerName} HP : {player.Health}");
    }
}