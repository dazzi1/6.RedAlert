using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//21.访问者模式
public abstract class ICharacterVisitor
{
    public abstract void VisitEnemy(IEnemy enemy);
    public abstract void VisitSoldier(ISoldier soldier);

}

