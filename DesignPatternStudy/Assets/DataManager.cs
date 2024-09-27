using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// 원본 객체와 장식된 객체 모두를 묶는 인터페이스
interface IData
{
    void setData(int data);
    int getData();
}

// 장식될 원본 객체
class MyData : IData
{
    private int data;

    public void setData(int data)
    {
        this.data = data;
    }

    public int getData()
    {
        return data;
    }
}

// 장식자 추상 클래스
abstract class MyDataDecorator : IData
{
    private IData mydataObj; // 최상위 인터페이스 타입으로 장식할 원본 객체 선언

    protected MyDataDecorator(IData mydataObj) 
    {
        this.mydataObj = mydataObj;
    }

    public virtual void setData(int data)
    {
        this.mydataObj.setData(data); 
    }

    public virtual int getData()
    {
        return mydataObj.getData(); 
    }
}

// 장식자 클래스
class SynchronizedDecorator : MyDataDecorator
{
    private readonly object syncLock = new object(); // lock에 사용할 객체

    public SynchronizedDecorator(IData mydataObj) : base(mydataObj)
    {
    }

    public override void setData(int data)
    {
        lock (syncLock)
        {
            Debug.Log("동기화된 data 처리를 시작합니다.");
            base.setData(data); // 부모 클래스의 setData 호출
            Debug.Log("동기화된 data 처리를 완료했습니다.");
        }
    }

    public override int getData()
    {
        lock (syncLock)
        {
            Debug.Log("동기화된 data 처리를 시작합니다.");
            int result = base.getData(); // 부모 클래스의 getData 호출
            Debug.Log("동기화된 data 처리를 완료했습니다.");
            return result;
        }
    }
}

// 나중에 기능 추가가 되도 수정없이 유연하게 클래스만 정의하면 추가 가능
class AnotherSkillDecorator : MyDataDecorator
{
    private IData mydataObj;

    public AnotherSkillDecorator(IData mydataObj) : base(mydataObj)
    {
    }
    
    // 추가 기능 --- 
}

public class DataManager : MonoBehaviour
{
    public void Start()
    {
        // 동시성이 필요없을 때
        IData data = new MyData();
        
        // 동시성이 필요할 때
        IData dataSync = new SynchronizedDecorator(data);
        dataSync.setData(13579);
        Debug.Log(dataSync.getData());
    }
}
