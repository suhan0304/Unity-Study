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

// EquipmentData를 출력
public class Message
{
    private EquipmentData equipment;

    public Message(EquipmentData equipment)
    {
        this.equipment = equipment;
    }

    public string MakeName()
    {
        return "Name : \"" + equipment.getName() + "\"";
    }

    public string MakePhysicalDamage()
    {
        return "Physical Damage : " + equipment.getPhysicalDamage();
    }

    public string MakeMagicalDamage()
    {
        return "Magical Damage : " + equipment.getMagicalDamage();
    }

    public string MakeAttackSpeed()
    {
        return "Attack Speed : " + equipment.getAttackSpeed();
    }
}

// Facade 패턴 클래스
public class EquipmentFacade
{
    private DBMS dbms = new DBMS();
    private Cache cache = new Cache();

    // 장비 데이터를 데이터베이스에 넣는 메소드
    public void InsertEquipmentData()
    {
        dbms.Put("Sword", new EquipmentData("Sword", 50, 20, 1.5f));
        dbms.Put("Staff", new EquipmentData("Staff", 10, 60, 1.2f));
        dbms.Put("Dagger", new EquipmentData("Dagger", 30, 10, 2.0f));
    }

    // 장비 데이터를 캐시에서 먼저 확인하고 없으면 DB에서 가져오는 메소드
    public void QueryAndDisplayEquipmentData(string name)
    {
        EquipmentData equipment = cache.Get(name);

        // 1. 만약 캐시에 없다면
        if (equipment == null)
        {
            equipment = dbms.Query(name); // DB에 해당 데이터를 조회
            if (equipment != null)
            {
                cache.Put(equipment); // 캐시에 저장
            }
        }

        // 2. dbms.Query(name)에서 조회된 값이 있으면
        if (equipment != null)
        {
            Message message = new Message(equipment);

            Debug.Log(message.MakeName());
            Debug.Log(message.MakePhysicalDamage());
            Debug.Log(message.MakeMagicalDamage());
            Debug.Log(message.MakeAttackSpeed());
        }
        // 3. 조회된 값이 없으면
        else
        {
            Debug.Log($"{name} 가 데이터베이스에 존재하지 않습니다.");
        }
    }
}
public class EquipmentManager : MonoBehaviour
{
    void Start()
    {
        // 1. 퍼사드 객체 생성
        EquipmentFacade facade = new EquipmentFacade();

        // 2. DB 값 insert
        facade.InsertEquipmentData();

        // 3. 퍼사드로 데이터베이스 & 캐싱 & 메시징 로직을 한번에 조회
        string name = "Staff";
        facade.QueryAndDisplayEquipmentData(name);
    }
}
