using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM13Decorator : MonoBehaviour {

	void Start () {
		Coffee coffee = new Espresso();
		coffee = coffee.AddDecorator(new Mocha());
		coffee = coffee.AddDecorator(new Mocha());
		coffee = coffee.AddDecorator(new Whip());
		Debug.Log(coffee.Cost());
		Debug.Log(coffee.Capacity());
	}
}

public abstract class Coffee {
	public abstract double Cost();
	public abstract double Capacity();
	public Coffee AddDecorator(Decorator decorator) {
		decorator.coffee = this;
		return decorator;
	}
}

public class Espresso : Coffee
{
    public override double Capacity()
    {
		return 10;
	}

    public override double Cost()
    {
		return 2.5;
    }
}

public class Decaf : Coffee
{
    public override double Capacity()
    {
		return 10;
	}

    public override double Cost()
	{
		return 2;
	}
}

public class Decorator : Coffee{
	protected Coffee mCoffee;
	public Coffee coffee {
		set { mCoffee = value; }
	}

    public override double Capacity()
    {
		return 10;
	}

    //public Decorator(Coffee coffee) {
    //	mCoffee = coffee;
    //}

    public override double Cost()
    {
		return mCoffee.Cost();
    }
}

public class Mocha : Decorator
{
	//public Mocha(Coffee coffee):base(coffee) {
	//}
	public override double Cost() {
		return mCoffee.Cost() + 0.1;
	}
}

public class Whip : Decorator
{
	//public Whip(Coffee coffee) : base(coffee)
	//{
	//}
	public override double Cost()
	{
		return mCoffee.Cost() + 0.5;
	}
}