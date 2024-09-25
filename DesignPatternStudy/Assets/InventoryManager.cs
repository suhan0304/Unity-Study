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
        // A_InventorySystem의 기능 사용
        aInventorySystem.ResetInventory();
        bInventory