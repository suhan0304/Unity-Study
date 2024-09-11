using System;
using UnityEngine;

public class Monster 
{
    int type;
    string name;
    int hp;
    bool agressive; 

    public String PrintAboutMonster() {
        return string.Format("Monster {{ type: '{0}', name: '{1}', HP: '{2}', agressive: '{3}' }}", type, name, hp, agressive);
    }
}
