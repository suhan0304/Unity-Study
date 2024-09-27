using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 원본 객체와 장식된 객체 모두를 묶는 인터페이스
public interface Weapon
{
    public void aim_and_fire();
}

// 장식될 원본 객체
class BaseWeapon : Weapon
{
    public void aim_and_fire()
    {
        Debug.Log("총알 발사");
    }
}

// 장식자 추상 클래스
public abstract class WeaponAccessory : Weapon
{
    private Weapon rifle;
    
    protected WeaponAccessory(Weapon rifle) { this.rifle = rifle; }

    public virtual void aim_and_fire()
    {
        rifle.aim_and_fire();
    }
}

// 장식자 클래스 (유탄 발사기)
class Generade : WeaponAccessory
{
    public Generade(Weapon rifle) : base(rifle)
    {
    }

    public override void aim_and_fire()
    {
        base.aim_and_fire();
        generade_fire();
    }

    private void generade_fire()
    {
        Debug.Log("유탄 발사");
    }
}

// 장식자 클래스 (조준경)
class Scoped : WeaponAccessory
{
    public Scoped(Weapon rifle) : base(rifle)
    {
    }

    public override void aim_and_fire()
    {
        aiming();
        base.aim_and_fire();
    }

    private void aiming()
    {
        Debug.Log("조준 중..");
    }
}

// 장식자 클래스 (개머리판)
class Buttstock : WeaponAccessory
{
    public Buttstock(Weapon rifle) : base(rifle)
    {
    }

    public override void aim_and_fire()
    {
        holding();
        base.aim_and_fire();
    }

    private void holding()
    {
        Debug.Log("견착 완료...");
    }
}