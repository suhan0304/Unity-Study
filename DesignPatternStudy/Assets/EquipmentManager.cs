using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class EquipmentData {
    private string name;
    private int physicalDamage;
    private int magicalDamage;
    private float attackSpeed;

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