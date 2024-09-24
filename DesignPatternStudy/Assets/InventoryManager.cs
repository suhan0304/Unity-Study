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

interface IInventorySystem
{
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
class B_InventorySystem  : IInventorySystem
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

class Inventory
{
    IInventorySystem _inventorySystem;
    //public void SetSystem(IInventorySystem inventorySystem) { this._inventorySystem = inventorySystem; }

    public void AddItemToInventory(Item item, SaveLocation saveLocation)
    {
        B_InventorySystem BinventorySystem = _inventorySystem as B_InventorySystem;
        
        BinventorySystem.AddItemToSaveLocation(item, saveLocation);
    }

    public void RemoveItemFromInventory(Item item, SaveLocation saveLocation)
    {
        B_InventorySystem BinventorySystem = _inventorySystem as B_InventorySystem;
    
        BinventorySystem.RemoveItemToSaveLocation(item, saveLocation);
    }

    public void ResetIventory()
    {
        A_InventorySystem AinventorySystem = _inventorySystem as A_InventorySystem;
        B_InventorySystem BinventorySystem = _inventorySystem as B_InventorySystem;
        
        // 인벤토리 초기화 후 Sync로 클라우드와 동기화
        AinventorySystem.ResetInventory();
        BinventorySystem.SyncInventory();
    }
}

class inventoryManager : MonoBehaviour
{
    void Start()
    {
        Inventory inventory = new Inventory();
        inventory.SetSystem(new A_InventorySystem());
    }
}