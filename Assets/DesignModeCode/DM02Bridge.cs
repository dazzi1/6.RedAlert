using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class DM02Bridge : MonoBehaviour
{
    void Start() {
        //更改后全变
        //IRenderEngine renderEngine = new DirectX();
        //IRenderEngine renderEngine = new SuperRender();

        //Sphere sphere = new Sphere(renderEngine);
        //sphere.Draw();
        //Cube cube = new Cube(renderEngine);
        //cube.Draw();
        //Capsule capsule = new Capsule(renderEngine);
        //capsule.Draw();
        
        ICharacter character = new SoldierCaptain();
        //WeaponGun gun = new WeaponGun();
        //character.gun = gun;

        //5.桥接模式
        //character.weapon = new WeaponLaser();
        //character.Attack(character);
    }
}

public class IShape {
    public string name;
    public IRenderEngine renderEngine;

    public IShape(IRenderEngine renderEngine) {
        this.renderEngine = renderEngine;
    }

    public void Draw() {
        renderEngine.Render(name);
    }
}
public abstract class IRenderEngine 
{
    public abstract void Render(string name);
}

public class Sphere : IShape{
    public Sphere(IRenderEngine re):base(re) {
        name = "Sphere";
    }
}

public class Cube : IShape
{
    public Cube(IRenderEngine re) : base(re)
    {
        name = "Cube";
    }
}

public class Capsule : IShape
{
    public Capsule(IRenderEngine re) : base(re)
    {
        name = "Capsule";
    }
}

public class OpenGL : IRenderEngine
{
    public override void Render ( string name)
    {
        Debug.Log("OpenGL绘制出来了：" + name);
    }
}

public class DirectX : IRenderEngine
{
    public override void Render(String name) {
        Debug.Log("DirectX绘制出来了：" + name);
    }
}

public class SuperRender : IRenderEngine {
    public override void Render(string name)
    {
        Debug.Log("SuperRender绘制出来了：" + name);
    }
}
