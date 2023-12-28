using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class SoldierKilledObserverAchievement : IGameEventObserver
{
    private AchievementSystem mArchSystem;
    public SoldierKilledObserverAchievement(AchievementSystem archSystem) {
        mArchSystem = archSystem;
    }

    public override void Update()
    {
        mArchSystem.AddSoldierKilledCount();
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        return;
    }

    
}

