using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string Name { get; set; }
    public DateTime AcquisitionDate { get; set; }
    public int Quantity { get; set; }

    public Item(string name, int quantity, DateTime acquisitionDate)
    {
        Name = name;
        Quantity = quantity;
        AcquisitionDate = acquisitionDate;
    }
}

public class ItemInventory : IEnumerable<Item>
{
    private List<Item> items = new List<Item>();

    public void AddItem(string name, int quantity, DateTime acquisitionDate)
    {
        items.Add(new Item(name, quantity, acquisitionDate));
    }

    public List<Item> GetItems()
    {
        return items;
    }

    // 수량 순서 이터레이터 반환
    public IEnumerator<Item> GetQuantityItemIterator()
    {
        return new QuantityItemIterator(items);
    }

    // 날짜 순서 이터레이터 반환
    public IEnumerator<Item> GetDateItemIterator()
    {
        return new DateItemIterator(items);
    }

    // IEnumerable<Item>의 GetEnumerator 구현
    public IEnumerator<Item> GetEnumerator()
    {
        return items.GetEnumerator(); // 기본 발행 순서
    }

    // IEnumerable의 GetEnumerator 구현 (비제네릭 버전)
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// 수량 순서 이터레이터
public class QuantityItemIterator : IEnumerator<Item>
{
    private List<Item> items;
    private int position = -1;

    public QuantityItemIterator(List<Item> items)
    {
        // 수량 순으로 정렬
        this.items = new List<Item>(items);
        this.items.Sort((i1, i2) => i1.Quantity.CompareTo(i2.Quantity));
    }

    public bool MoveNext()
    {
        position++;
        return position < items.Count;
    }

    public void Reset()
    {
        position = -1;
    }

    public Item Current
    {
        get
        {
            if (position < 0 || position >= items.Count)
                throw new InvalidOperationException();
            return items[position];
        }
    }

    object IEnumerator.Current => Current;

    public void Dispose() { }
}

// 날짜 순서 이터레이터
public class DateItemIterator : IEnumerator<Item>
{
    private List<Item> items;
    private int position = -1;

    public DateItemIterator(List<Item> items)
    {
        // 날짜 순으로 정렬
        this.items = new List<Item>(items);
        this.items.Sort((i1, i2) => i1.AcquisitionDate.CompareTo(i2.AcquisitionDate));
    }

    public bool MoveNext()
    {
        position++;
        return position < items.Count;
    }

    public void Reset()
    {
        position = -1;
    }

    public Item Current
    {
        get
        {
            if (position < 0 || position >= items.Count)
                throw new InvalidOperationException();
            return items[position];
        }
    }

    object IEnumerator.Current => Current;

    public void Dispose() { }
}

public class InventoryWithSort : MonoBehaviour
{
    void Start()
    {
        // 1. 인벤토리 생성
        ItemInventory itemInventory = new ItemInventory();

        // 2. 인벤토리에 아이템 추가
        itemInventory.AddItem("Sword", 2, new DateTime(2024, 10, 7));
        itemInventory.AddItem("Potion", 5, new DateTime(2024, 5, 12));
        itemInventory.AddItem("Shield", 1, new DateTime(2024, 8, 23));
        itemInventory.AddItem("Bow", 3, new DateTime(2024, 12, 1));

        // 3. 아이템 수량 순서대로 조회
        Debug.Log("Items sorted by quantity:");
        Print(itemInventory.GetQuantityItemIterator());

        // 4. 아이템 날짜 순서대로 조회
        Debug.Log("Items sorted by acquisition date:");
        Print(itemInventory.GetDateItemIterator());
    }

    
    void Print(IEnumerator<Item> iterator)
    {
        while (iterator.MoveNext())
        {
            Item item = iterator.Current;
            Debug.Log($"{item.Name} / {item.Quantity} / {item.AcquisitionDate}");
        }
    }
}
