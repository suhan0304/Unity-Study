using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Item
{
    public string name;
    public string description;
}

interface IInventorySystem
{
    void AddItem(Item item); 
    void RemoveItem(Item item);
    void ResetInventory();
}

class A_InventorySystem : IInventorySystem
{
    public void AddItem(Item item) {}
    public void RemoveItem(Item item) {}
    public void ResetInventory() {}
}

enum SaveLocation
{
    Local,
    Cloud,
    Both
}
class B_InventorySystem
{
    public void AddItemToSaveLocation(Item item, SaveLocation saveLocation) {}
    public void RemoveItemToSaveLocation(Item item, SaveLocation saveLocation) {}
    public void SyncInventory() {}
}

class Inventory
{
    IInventorySystem _inventorySystem;

    public void SetSystem(IInventorySystem inventorySystem)
    {
        this._inventorySystem = inventorySystem;
    }

    public void AddItemToInventory(Item item)
    {
        _inventorySystem.AddItem(item);
    }

    public void RemoveItemFromInventory(Item item)
    {
        _inventorySystem.RemoveItem(item);
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