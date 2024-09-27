using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

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

class timerMeasureDecorator : MyDataDecorator
{
    public timerMeasureDecorator (IData mydataObj) : base(mydataObj)
    {
    }

    public override void setData(int data)
    {
        Stopwatch stopwatch = Stopwatch.StartNew(); // 시간 측정 시작
        base.setData(data);
        stopwatch.Stop(); // 시간 측정 종료
        Debug.Log(stopwatch.ElapsedTicks + " ticks"); 
    }

    public override int getData()
    {
        Stopwatch stopwatch = Stopwatch.StartNew(); // 시간 측정 시작
        int result = base.getData();
        stopwatch.Stop(); // 시간 측정 종료
        Debug.Log(stopwatch.ElapsedTicks + " ticks"); 
        return result;
    }
}

public class DataManager : MonoBehaviour
{
    public void Start()
    {
        IData data = new MyData();
        
        // 시간 측정 하고 싶을 때
        IData data1 = new timerMeasureDecorator(data);
        data1.setData(13579);
        
        Debug.Log("------------");
        
        // 동서시성이 적용된 로직 안의 코드의 시간 측정을 하고 싶을 때
        IData data2 = new SynchronizedDecorator(new timerMeasureDecorator(data));
        data2.setData(24680);
        Debug.Log(data2.getData());
        
        Debug.Log("------------");
        
        // 동시성이 적용된 코드를 시간 측정을 하고 싶을 때
        IData data3 = new timerMeasureDecorator(new SynchronizedDecorator(data));
        data3.setData(99999);
        Debug.Log(data3.getData());
    }
}
