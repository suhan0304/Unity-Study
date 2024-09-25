using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

enum SaveLocation
{
    Local,
    Cloud,
    Both
}

public class Item
{
    public string name;
    public string description;
}

// 기존의 인터페이스는 수정하지 않는다.
interface IInventorySystem 
{
    void AddItem(Item item);
    void RemoveItem(Item item);
    void ResetInventory();
}

class A_InventorySystem : IInventorySystem
{
    private List<Item> sharedItems;

    // 공유된 인벤토리를 받는다.
    public A_InventorySystem(List<Item> sharedItems)
    {
        this.sharedItems = sharedItems;
    }

    public void AddItem(Item item)
    {
        sharedItems.Add(item);
        Debug.Log(item.name + " was added to A_InventorySystem.");
    }

    public void RemoveItem(Item item)
    {
        sharedItems.Remove(item);
        Debug.Log(item.name + " was removed from A_InventorySystem.");
    }

    public void ResetInventory()
    {
        sharedItems.Clear();
        Debug.Log("A_InventorySystem inventory reset.");
    }
}

class B_InventorySystem 
{
    private List<Item> sharedItems;

    // 공유된 인벤토리를 받는다.
    public B_InventorySystem(List<Item> sharedItems)
    {
        this.sharedItems = sharedItems;
    }

    public void AddItemToSaveLocation(Item item, SaveLocation saveLocation)
    {
        sharedItems.Add(item);
        Debug.Log(item.name + " was added to B_InventorySystem at " + saveLocation.ToString());
    }

    public void RemoveItemToSaveLocation(Item item, SaveLocation saveLocation)
    {
        sharedItems.Remove(item);
        Debug.Log(item.name + " was removed from B_InventorySystem at " + saveLocation.ToString());
    }

    public void SyncInventory()
    {
        Debug.Log("B_InventorySystem inventory synced.");
    }
}
// 객체 어댑터 패턴으로 변경한 InventorySystemAdaptor
class InventorySystemAdaptor : IInventorySystem
{
    A_InventorySystem aInventorySystem;
    B_InventorySystem bInventorySystem;

    // 생성자를 통해 두 시스템을 받는다.
    public InventorySystemAdaptor(A_InventorySystem aInventorySystem, B_InventorySystem bInventorySystem)
    {
        this.aInventorySystem = aInventorySystem;
        this.bInventorySystem = bInventorySystem;
    }

    public void AddItem(Item item)
    {
        // B_InventorySystem의 기능 사용
        bInventorySystem.AddItemToSaveLocation(item, SaveLocation.Local);
        bInventorySystem.SyncInventory();
    }

    public void RemoveItem(Item item)
    {
        // B_InventorySystem의 기능 사용
        bInventorySystem.RemoveItemToSaveLocation(item, SaveLocation.Local);
        bInventorySystem.SyncInventory();
    }

    public void ResetInventory()
    {
        aInventorySystem.ResetInventory();
        bInventorySystem.SyncInventory();
    }
}

class Inventory
{
    IInventorySystem _inventorySystem;

    public void setInventorySystem(IInventorySystem inventorySystem)
    {
        _inventorySystem = inventorySystem;
    }

    public void AddItem(Item item)
    {
        _inventorySystem.AddItem(item);
    }

    public void RemoveItem(Item item)
    {
        _inventorySystem.RemoveItem(item);
    }

    public void ResetInventory()
    {
        _inventorySystem.ResetInventory();
    }
}

class InventoryManager : MonoBehaviour
{
    void Start()
    {
        // 공유 인벤토리 리스트 생성
        List<Item> sharedInventory = new List<Item>();

        // A와 B 시스템에 동일한 공유 인벤토리 리스트를 전달
        A_InventorySystem aInventory = new A_InventorySystem(sharedInventory);
        B_InventorySystem bInventory = new B_InventorySystem(sharedInventory);

        // 어댑터 패턴으로 A와 B 시스템을 통합
        IInventorySystem adaptor = new InventorySystemAdaptor(aInventory, bInventory);
        Inventory inventory = new Inventory();
        inventory.setInventorySystem(adaptor);

        // 테스트용 아이템 생성
        Item newItem = new Item { name = "Sword", description = "A sharp blade" };
        inventory.AddItem(newItem);  // 아이템 추가
        inventory.ResetInventory();  // 인벤토리 초기화
    }
}