using System;
using UnityEngine;

public class Monster 
{
    public int type;
    public string name;
    public int hp;
    public bool agressive; 

    public String PrintAboutMonster() {
        return string.Format("Monster {{ type: '{0}', name: '{1}', HP: '{2}', agressive: '{3}' }}", type, name, hp, agressive);
    }
}
