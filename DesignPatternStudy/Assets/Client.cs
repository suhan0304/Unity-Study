using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    void Start()
    {
        Player player = new Player(100);

        HealthUI ui1 = new HealthUI("HealthBar");
        HealthUI ui2 = new HealthUI("HealthText");
        HealthUI ui3 = new HealthUI("Status");
        
        player.RegisterObserver(ui1);
        player.RegisterObserver(ui2);
        player.RegisterObserver(ui3);
        
        player.TakeDamage(20);
        
        player.RemoveObserver(ui2);
        
        player.TakeDamage(15);
        
    }
}
