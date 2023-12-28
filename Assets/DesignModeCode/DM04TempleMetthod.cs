using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//7.模板方法模式
public class DM04TempleMetthod : MonoBehaviour
{
    void Start() {
        //IPeople people = new SouthPeople();
        IPeople people = new NorthPeople();
        people.Eat();
    }
}

public abstract class IPeople {
    //模板方法
    public void Eat() {
        OrderFoods();
        EatSomething();
        PayBill();
    }
    private void OrderFoods() {
        Debug.Log("点单");
    }
    protected virtual void EatSomething() {
        
    }
    private void PayBill() {
        Debug.Log("买单");
    }
}

public class NorthPeople : IPeople {
    protected override void EatSomething()
    {
        Debug.Log("我在吃面条");
    }
}

public class SouthPeople : IPeople {
    protected override void EatSomething()
    {
        Debug.Log("我在吃米饭");
    }
}

