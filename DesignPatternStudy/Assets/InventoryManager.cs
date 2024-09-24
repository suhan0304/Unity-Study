using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public void AddItem(Item item)
    {
        // 인벤토리 아이템 추가 로직
    }

    public void RemoveItem(Item item)
    {
        // 인벤토리 아이템 삭제 로직
    }

    public void ResetInventory()
    {
        // 인벤토리 초기화 로직
    }
}
class B_InventorySystem 
{
    public void AddItemToSaveLocation(Item item, SaveLocation saveLocation)
    {
        // saveLocation에 item 추가
    }

    public void RemoveItemToSaveLocation(Item item, SaveLocation saveLocation)
    {
        // saveLocation에 item 삭제
    }

    public void SyncInventory()
    {
        // Local과 Cloud 인벤토리 동기화
    }
}

class InventorySystemAdaptor : IInventorySystem
{
    A_InventorySystem AinventorySystem;
    B_InventorySystem BinventorySystem;

    public InventorySystemAdaptor(A_InventorySystem AinventorySystem, B_InventorySystem BinventorySystem)
    {
        this.AinventorySystem = AinventorySystem;
        this.BinventorySystem = BinventorySystem;
    }

    public void AddItem(Item item)
    {
        BinventorySystem.AddItemToSaveLocation(item, SaveLocation.Local);
        BinventorySystem.SyncInventory();
    }

    public void RemoveItem(Item item)
    {
        BinventorySystem.RemoveItemToSaveLocation(item, SaveLocation.Local);
        BinventorySystem.SyncInventory();
    }

    public void ResetInventory()
    {
        AinventorySystem.ResetInventory();
        BinventorySystem.SyncInventory();
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

class inventoryManager : MonoBehaviour
{
    void Start()
    {
        IInventorySystem adaptor = new InventorySystemAdaptor(new A_InventorySystem(), new B_InventorySystem());
        Inventory inventory = new Inventory();
        inventory.setInventorySystem(adaptor);
    }
}