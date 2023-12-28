using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//21.访问者模式
public class DM11Visitor:MonoBehaviour
{
    void Start() {
        DMShpere shpere1 = new DMShpere();
        DMCylinder cylinder1 = new DMCylinder();
        DMCube cube1 = new DMCube();
        DMCube cube2 = new DMCube();

        DMShapeContainer container = new DMShapeContainer();
        container.AddShape(shpere1);
        container.AddShape(cylinder1);
        container.AddShape(cube1);
        container.AddShape(cube2);

        //int count = container.GetShapeCount();
        //int cubeCount = container.GetCubeCount();
        AmountVisitor amountVisitor = new AmountVisitor();
        container.RunVisitor(amountVisitor);
        int amount = amountVisitor.amount;
        Debug.Log("图形总数" + amount);

        CubeAmountVisitor cubeAmountVisitor = new CubeAmountVisitor();
        container.RunVisitor(cubeAmountVisitor);
        int cubeAmount = cubeAmountVisitor.amount;
        Debug.Log("cube总数" + cubeAmount);

        EdgeVisitor edgeVisitor = new EdgeVisitor();
        container.RunVisitor(edgeVisitor);
        int edgeAmount = edgeVisitor.amount;
        Debug.Log("边总数" + edgeAmount);
    }
}

class DMShapeContainer {
    private List<IDMShape> mShapes = new List<IDMShape>();
    public void AddShape(IDMShape shape) {
        mShapes.Add(shape);
    }
    public void RunVisitor(IShapeVisitor visitor) {
        foreach (IDMShape shape in mShapes)
        {
            shape.RunVisitor(visitor);
        }
    }
    //public int GetShapeCount() {
    //    return mShapes.Count;
    //}
    //public int GetCubeCount() {
    //    int count = 0;
    //    foreach (IDMShape shape in mShapes)
    //    {
    //        if (shape.GetType() == typeof(DMCube))
    //        {
    //            count++;
    //        }
    //    }
    //    return count;
    //}
    //public int GetVolume() {
    //    int temp = 0;
    //    foreach (IDMShape shape in mShapes)
    //    {
    //        temp += shape.GetVolume();
    //    }
    //    return temp;
    //}
}

abstract class IDMShape{
    //public abstract int GetVolume();
    public abstract void RunVisitor(IShapeVisitor visitor);
}
class DMShpere : IDMShape
{
    //public override int GetVolume()
    //{
    //    return 30;
    //}

    public override void RunVisitor(IShapeVisitor visitor)
    {
        visitor.VisitSphere(this);
    }
}
class DMCylinder : IDMShape
{
    //public override int GetVolume()
    //{
    //    return 20;
    //}

    public override void RunVisitor(IShapeVisitor visitor)
    {
        visitor.VisitCylinder(this);
    }
}
class DMCube : IDMShape
{
    //public override int GetVolume()
    //{
    //    return 10;
    //}

    public override void RunVisitor(IShapeVisitor visitor)
    {
        visitor.VisitCube(this);
    }
}

abstract class IShapeVisitor {
    public abstract void VisitSphere(DMShpere sphare);
    public abstract void VisitCylinder(DMCylinder cylinder);
    public abstract void VisitCube(DMCube cube);
}
class AmountVisitor : IShapeVisitor
{
    public int amount = 0;
    public override void VisitCube(DMCube cube)
    {
        amount++;
    }

    public override void VisitCylinder(DMCylinder cylinder)
    {
        amount++;
    }

    public override void VisitSphere(DMShpere sphare)
    {
        amount++;
    }
}

class CubeAmountVisitor : IShapeVisitor
{
    public int amount = 0;
    public override void VisitCube(DMCube cube)
    {
        amount++;
    }

    public override void VisitCylinder(DMCylinder cylinder)
    {
        return;
    }

    public override void VisitSphere(DMShpere sphare)
    {
        return;
    }
}

class EdgeVisitor : IShapeVisitor {
    public int amount = 0;

    public override void VisitCube(DMCube cube)
    {
        amount += 12;
    }

    public override void VisitCylinder(DMCylinder cylinder)
    {
        amount += 2;
    }

    public override void VisitSphere(DMShpere sphare)
    {
        amount += 1;
    }
}

