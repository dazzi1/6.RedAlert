using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class DM09Observer:MonoBehaviour
{
    void Start() {
        //WeatherStation ws = new WeatherStation();
        //BillboardA a = new BillboardA();
        //BillboardB b = new BillboardB();
        //BillboardC c = new BillboardC();
        //ws.Update(a,b,c);

        ConcreteSubject1 sub1 = new ConcreteSubject1();

        ConcreteObserver1 ob1 = new ConcreteObserver1(sub1);
        sub1.RegisterObserver(ob1);

        ConcreteObserver2 ob2 = new ConcreteObserver2(sub1);
        sub1.RegisterObserver(ob2);

        sub1.subjectState = "温度 90";

    }
}

//class WeatherStation {

//    public void Update(BillboardA a,BillboardB b,BillboardC c) {
//        a.Show();
//        b.Show();
//        c.Show();
//    }
//}

//class BillboardA {
//    public void Show() {
//        Debug.Log("A布告板显示天气信息");
//    }
//}
//class BillboardB
//{
//    public void Show()
//    {
//        Debug.Log("B布告板显示天气信息");
//    }
//}
//class BillboardC
//{
//    public void Show()
//    {
//        Debug.Log("C布告板显示天气信息");
//    }
//}

public abstract class Subject{

    List<Observer> mObservers = new List<Observer>();

    public void RegisterObserver(Observer ob) {
        mObservers.Add(ob);
    }
    public void RemoveObserver(Observer ob) {
        mObservers.Remove(ob);
    }
    public void NotifyObserver() {
        foreach (Observer ob in mObservers)
        {
            ob.Update();
        }
    }
}

public class ConcreteSubject1 : Subject
{
    private string mSubjectState;
    public string subjectState {
        set { mSubjectState = value;
            NotifyObserver();
        }
        get { return mSubjectState; }
    }

}

public abstract class Observer {
    public abstract void Update();
}

public class ConcreteObserver1 : Observer
{
    public ConcreteSubject1 mSub;
    public ConcreteObserver1(ConcreteSubject1 sub) {
        mSub = sub;
    } 
    public override void Update()
    {
        Debug.Log("Observer1更新显示" + mSub.subjectState);
    }
}

public class ConcreteObserver2 : Observer
{
    public ConcreteSubject1 mSub;
    public ConcreteObserver2(ConcreteSubject1 sub)
    {
        mSub = sub;
    }
    public override void Update()
    {
        Debug.Log("Observer2更新显示" + mSub.subjectState);
    }
}

