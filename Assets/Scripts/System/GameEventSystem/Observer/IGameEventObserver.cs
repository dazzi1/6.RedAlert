using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public abstract class IGameEventObserver
{
    public abstract void Update();
    public abstract void SetSubject(IGameEventSubject sub);
}

