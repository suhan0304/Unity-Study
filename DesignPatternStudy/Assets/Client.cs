using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Client : MonoBehaviour
{
    void Start()
    {
        PlayerDelegate player = new PlayerDelegate(100);

        HealthUI ui1 = new HealthUI("HealthBar");
        HealthUI ui2 = new HealthUI("HealthText");
        HealthUI ui3 = new HealthUI("Status");

        player.OnHealthChanged += ui1.UpdateDelegate;
        player.OnHealthChanged += ui2.UpdateDelegate;
        player.OnHealthChanged += ui3.UpdateDelegate;

        player.TakeDamage(20);
        
        player.OnHealthChanged -= ui2.UpdateDelegate;

        player.TakeDamage(15);
    }
}
