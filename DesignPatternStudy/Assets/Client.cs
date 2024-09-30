using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    void Start()
    {
        Player player = new Player(100);

        List<IUI> uis = new List<IUI>
        {
            new HealthUI("HealthBar", player),
            new HealthUI("HealthText", player),
            new HealthUI("Status", player),
        };
        
        player.TakeDamage(20);

        foreach (IUI ui in uis)
        {
            ui.Display();
        }
    }
}
