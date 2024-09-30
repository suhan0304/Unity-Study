using UnityEngine;

class Player {
    public int Health { get; private set; }

    public Player(int health) {
        Health = health;
    }

    public void TakeDamage(int damage) {
        Health -= damage;
        if (Health < 0) Health = 0;
    }
}
