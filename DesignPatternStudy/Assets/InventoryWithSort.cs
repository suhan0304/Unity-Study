using System;
using System.Collections.Generic;

public class Item
{
    public string Name { get; set; } // 아이템 이름
    public DateTime AcquisitionDate { get; set; } // 획득 일자
    public int Quantity { get; set; } // 아이템 수량

    // 생성자: 수량과 획득 일자 설정 가능
    public Item(string name, int quantity, DateTime acquisitionDate)
    {
        Name = name;
        Quantity = quantity;
        AcquisitionDate = acquisitionDate;
    }

    // 기본 생성자: 획득 일자는 현재 시간으로 설정, 수량은 1
    public Item(string name)
    {
        Name = name;
        Quantity = 1;
        AcquisitionDate = DateTime.Now; // 현재 시각으로 설정
    }
}

public class ItemInventory
{
    private List<Item> items = new List<Item>(); // 아이템 리스트

    public void AddItem(string name, int quantity, DateTime acquisitionDate)
    {
        items.Add(new Item(name, quantity, acquisitionDate)); // 새로운 아이템 추가
    }

    public List<Item> GetItems()
    {
        return items; // 아이템 리스트 반환
    }
}

public class InventoryWithSort : UnityEngine.MonoBehaviour
{
    void Start()
    {
        // 1. 인벤토리 생성
        ItemInventory itemInventory = new ItemInventory();

        // 2. 인벤토리에 아이템 추가 (직접 날짜와 수량을 설정)
        itemInventory.AddItem("Sword", 2, new DateTime(2023, 10, 7));
        itemInventory.AddItem("Potion", 5, new DateTime(2023, 5, 12));
        itemInventory.AddItem("Shield", 1, new DateTime(2023, 8, 23));
        itemInventory.AddItem("Bow", 3, new DateTime(2023, 12, 1));

        // 3. 아이템 발행 순서대로 조회하기
        List<Item> items = itemInventory.GetItems();
        UnityEngine.Debug.Log("Items in added order:");
        foreach (Item item in items)
        {
            UnityEngine.Debug.Log($"{item.Name} / {item.Quantity} / {item.AcquisitionDate}");
        }

        // 4. 아이템을 날짜별로 정렬해서 조회하기
        items.Sort((i1, i2) => i1.AcquisitionDate.CompareTo(i2.AcquisitionDate)); // 획득 날짜별로 정렬
        UnityEngine.Debug.Log("Items sorted by acquisition date:");
        foreach (Item item in items)
        {
            UnityEngine.Debug.Log($"{item.Name} / {item.Quantity} / {item.AcquisitionDate}");
        }
    }
}
