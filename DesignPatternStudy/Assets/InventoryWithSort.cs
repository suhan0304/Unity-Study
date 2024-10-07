using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}

public interface IIterator<T>
{
    void First();               // 이터레이터를 첫 번째 항목으로 이동
    bool HasNext();            // 다음 항목이 있는지 확인
    T Next();                  // 다음 항목을 가져옴
    T CurrentItem { get; }     // 현재 항목 가져오기
    void Reset();              // 이터레이터를 처음 상태로 되돌림
}

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

public class ItemInventory : IAggregate<Item>
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

    public IIterator<Item> CreateIterator()
    {
        return new QuantityItemIterator(this);
    }

    public IIterator<Item> CreateDateIterator()
    {
        return new DateItemIterator(this);
    }

    private class QuantityItemIterator : IIterator<Item>
    {
        private List<Item> items;
        private int position = -1;

        public QuantityItemIterator(ItemInventory inventory)
        {
            items = new List<Item>(inventory.GetItems());
            items.Sort((i1, i2) => i1.Quantity.CompareTo(i2.Quantity));
            First(); // 초기화 시 첫 번째 아이템으로 설정
        }

        public void First()
        {
            position = -1; // 초기화
        }

        public bool HasNext()
        {
            return position + 1 < items.Count;
        }

        public Item Next()
        {
            if (!HasNext())
                throw new InvalidOperationException();

            position++;
            return items[position];
        }

        public Item CurrentItem
        {
            get
            {
                if (position < 0 || position >= items.Count)
                    throw new InvalidOperationException();
                return items[position];
            }
        }

        public void Reset()
        {
            First();
        }
    }

    private class DateItemIterator : IIterator<Item>
    {
        private List<Item> items;
        private int position = -1;

        public DateItemIterator(ItemInventory inventory)
        {
            items = new List<Item>(inventory.GetItems());
            items.Sort((i1, i2) => i1.AcquisitionDate.CompareTo(i2.AcquisitionDate));
            First(); // 초기화 시 첫 번째 아이템으로 설정
        }

        public void First()
        {
            position = -1; // 초기화
        }

        public bool HasNext()
        {
            return position + 1 < items.Count;
        }

        public Item Next()
        {
            if (!HasNext())
                throw new InvalidOperationException();

            position++;
            return items[position];
        }

        public Item CurrentItem
        {
            get
            {
                if (position < 0 || position >= items.Count)
                    throw new InvalidOperationException();
                return items[position];
            }
        }

        public void Reset()
        {
            First();
        }
    }
}

public class InventoryWithSort : MonoBehaviour
{
    void Start()
    {
        ItemInventory itemInventory = new ItemInventory();

        itemInventory.AddItem("Sword", 2, new DateTime(2024, 10, 7));
        itemInventory.AddItem("Potion", 5, new DateTime(2024, 5, 12));
        itemInventory.AddItem("Shield", 1, new DateTime(2024, 8, 23));
        itemInventory.AddItem("Bow", 3, new DateTime(2024, 12, 1));

        // 아이템 수량 순서대로 조회
        Debug.Log("Items sorted by quantity:");
        Print(itemInventory.CreateIterator());

        // 아이템 날짜 순서대로 조회
        Debug.Log("Items sorted by acquisition date:");
        Print(itemInventory.CreateDateIterator());
    }

    void Print(IIterator<Item> iterator)
    {
        while (iterator.HasNext())
        {
            Item item = iterator.Next();
            Debug.Log($"{item.Name} / {item.Quantity} / {item.AcquisitionDate}");
        }
    }
}