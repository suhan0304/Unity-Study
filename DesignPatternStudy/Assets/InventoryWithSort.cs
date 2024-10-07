using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item
{
    public string Name { get; set; } // 아이템 이름
    public DateTime AcquisitionDate { get; set; }

    public Item(string name)
    {
        Name = name;
        AcquisitionDate = DateTime.Now; // 현재 시각으로 설정
    }
}

public class ItemInventory
{
    private List<Item> items = new List<Item>(); // 아이템 리스트

    public void AddItem(string name)
    {
        items.Add(new Item(name)); // 새로운 아이템 추가
    }

    public List<Item> GetItems()
    {
        return items; // 아이템 리스트 반환
    }
}