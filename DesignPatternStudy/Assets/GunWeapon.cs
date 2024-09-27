using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Weapon
{
    void aim_and_fire()
    {
    }
}

class BaseWeapon : Weapon
{
    public void aim_and_fire()
    {
        Debug.Log("총알 발사");
    }
}

class GeneradeBaseWeapon : Weapon
{
    public void aim_and_fire()
    {
        Debug.Log("총알 발사");
    }
    public void generade_fire()
    {
        Debug.Log("유탄 발사");
    }
}

class ScopedBaseWeapon : Weapon
{
    public void aim_and_fire()
    {
        aiming();
        Debug.Log("조준하여 총알 발사");
    }
    public void aiming()
    {
        Debug.Log("조준 중...");
    }
}

class ButtstockScopedGeneradeBaseWeapon : Weapon
{
    public void aim_and_fire()
    {
        holding();
        aiming();
        Debug.Log("조준하여 총알 발사");
    }
    public void aiming()
    {
        Debug.Log("조준 중...");
    }
    public void holding()
    {
        Debug.Log("견착 완료...");
    }
}