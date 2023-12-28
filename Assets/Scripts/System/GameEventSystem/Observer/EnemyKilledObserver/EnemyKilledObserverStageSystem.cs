using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class EnemyKilledObserverStageSystem : IGameEventObserver
{
    private EnemyKilledSubject mSubject;
    private StageSystem mStageSystem;
    public EnemyKilledObserverStageSystem(StageSystem ss)
    {
        mStageSystem = ss;
    }
    public override void SetSubject(IGameEventSubject sub)
    {
        mSubject = sub as EnemyKilledSubject;
    }

    public override void Update()
    {
        mStageSystem.countOfEnemyKilled = mSubject.killedCount;
    }
}

