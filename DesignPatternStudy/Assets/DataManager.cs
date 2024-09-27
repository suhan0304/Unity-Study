using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class MyData
{
    private int data;

    public virtual void setData(int data)
    {
        this.data = data;
    }

    public virtual int getData()
    {
        return this.data;
    }
}

class SynchronizedData : MyData
{
    private readonly object syncLock = new object();

    public override void setData(int data)
    {
        lock (syncLock)
        {
            base.setData(data);
        }
    }

    public override int getData()
    {
        lock (syncLock)
        {
            return base.getData();
        }
    }
}


public class DataManager : MonoBehaviour
{
    public void Start()
    {
        SynchronizedData data = new SynchronizedData();
        data.setData(1234);
        Debug.Log(data.getData());
    }
}
