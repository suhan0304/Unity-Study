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

[System.Serializable]
public class ItemObject
{
    public string name;
    public string description;
}

// 기존의 인터페이스는 수정하지 않는다.
interface IInventorySystem 
{
    void AddItemObject(ItemObject item);
    void RemoveItemObject(ItemObject item);
    void ResetInventory();
}

class A_InventorySystem : IInventorySystem
{
    private List<ItemObject> sharedItemObjects;

    // 공유된 인벤토리를 받는다.
    public A_InventorySystem(List<ItemObject> sharedItemObjects)
    {
        this.sharedItemObjects = sharedItemObjects;
    }

    public void AddItemObject(ItemObject item)
    {
        sharedItemObjects.Add(item);
        Debug.Log(item.name + " was added to Inventory.");
    }

    public void RemoveItemObject(ItemObject item)
    {
        sharedItemObjects.Remove(item);
        Debug.Log(item.name + " was removed from Inventory.");
    }

    public void ResetInventory()
    {
        sharedItemObjects.Clear();
        Debug.Log("Inventory inventory reset.");
    }
}

class B_InventorySystem 
{
    private List<ItemObject> sharedItemObjects;

    // 공유된 인벤토리를 받는다.
    public B_InventorySystem(List<ItemObject> sharedItemObjects)
    {
        this.sharedItemObjects = sharedItemObjects;
    }

    public void AddItemObjectToSaveLocation(ItemObject item, SaveLocation saveLocation)
    {
        sharedItemObjects.Add(item);
        Debug.Log(item.name + " was added to Inventory at " + saveLocation.ToString());
    }

    public void RemoveItemObjectToSaveLocation(ItemObject item, SaveLocation saveLocation)
    {
        sharedItemObjects.Remove(item);
        Debug.Log(item.name + " was removed from Inventory at " + saveLocation.ToString());
    }

    public void SyncInventory()
    {
        Debug.Log("Local + Save Inventory inventory synced.");
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

    public void AddItemObject(ItemObject item)
    {
        // B_InventorySystem의 기능 사용
        bInventorySystem.AddItemObjectToSaveLocation(item, SaveLocation.Local);
        bInventorySystem.SyncInventory();
    }

    public void RemoveItemObject(ItemObject item)
    {
        // B_InventorySystem의 기능 사용
        bInventorySystem.RemoveItemObjectToSaveLocation(item, SaveLocation.Local);
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

    public void AddItemObject(ItemObject item)
    {
        _inventorySystem.AddItemObject(item);
    }

    public void RemoveItemObject(ItemObject item)
    {
        _inventorySystem.RemoveItemObject(item);
    }

    public void ResetInventory()
    {
        _inventorySystem.ResetInventory();
    }
}


public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    // 공유 인벤토리 리스트 생성
    private List<ItemObject> sharedInventory = new List<ItemObject>();
    
    void Start()
    {

        // A와 B 시스템에 동일한 공유 인벤토리 리스트를 전달
        A_InventorySystem aInventory = new A_InventorySystem(sharedInventory);
        B_InventorySystem bInventory = new B_InventorySystem(sharedInventory);

        // 어댑터 패턴으로 A와 B 시스템을 통합
        IInventorySystem adaptor = new InventorySystemAdaptor(aInventory, bInventory);
        Inventory inventory = new Inventory();
        inventory.setInventorySystem(adaptor);

        // 테스트용 아이템 생성
        ItemObject newItemObject = new ItemObject { name = "Sword", description = "A sharp blade" };
        inventory.AddItemObject(newItemObject);  // 아이템 추가
        //inventory.ResetInventory();  // 인벤토리 초기화
    }
}