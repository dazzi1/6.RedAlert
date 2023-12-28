using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class EnemyKillObserverAchievement:IGameEventObserver
{
    //private EnemyKilledSubject mSubject;
    private AchievementSystem mArchSystem;
    public EnemyKillObserverAchievement(AchievementSystem archSystem) {
        mArchSystem = archSystem;
    }

    public override void Update()
    {
        mArchSystem.AddEnemyKilledCount();
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        //mSubject = sub as EnemyKilledSubject;
    }

    
}

