using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EquipmentData {
    private string name;
    private int physicalDamage;
    private int magicalDamage;
    private float attackSpeed;

    public string getName()
    {
        return this.name;
    }

    public int getPhysicalDamage()
    {
        return this.physicalDamage;
    }

    public int getMagicalDamage()
    {
        return this.magicalDamage;
    }

    public float getAttackSpeed()
    {
        return this.attackSpeed;
    }


    public EquipmentData(string name, int physicalDamage, int magicalDamage, float attackSpeed) {
        this.name = name;
        this.physicalDamage = physicalDamage;
        this.magicalDamage = magicalDamage;
        this.attackSpeed = attackSpeed;
    }
 }

// 데이터 베이스 역할을 하는 클래스
public class DBMS
{
    private Dictionary<string, EquipmentData> db = new Dictionary<string, EquipmentData>();

    public void Put(string name, EquipmentData equipment)
    {
        db[name.ToLower()] = equipment;
    }

    // 데이터베이스에 쿼리를 날려 결과를 받아오는 메소드
    public EquipmentData Query(string name)
    {
        try
        {
            Thread.Sleep(500); // DB 조회 시간을 비유하여 0.5초 대기로 구현
        }
        catch (ThreadInterruptedException) {}

        db.TryGetValue(name.ToLower(), out var equipment);
        return equipment;
    }
}

// DBMS에서 조회된 데이터를 임시로 담아두는 클래스 *속도향상*
public class Cache
{
    private Dictionary<string, EquipmentData> cache = new Dictionary<string, EquipmentData>();

    public void Put(EquipmentData equipment)
    {
        cache[equipment.getName().ToLower()] = equipment;
    }

    public EquipmentData Get(string name)
    {
        cache.TryGetValue(name.ToLower(), out var equipment);
        return equipment;
    }
}
