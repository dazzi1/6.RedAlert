using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class NewStageObserverAchievement : IGameEventObserver
{
    private NewStageSubject mSubject;

    private AchievementSystem mArchSystem;
    public NewStageObserverAchievement(AchievementSystem archSystem)
    {
        mArchSystem = archSystem;
    }
    public override void Update()
    {
        mArchSystem.SetMaxStageLv(mSubject.stageCount);
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        mSubject = sub as NewStageSubject;
    }

    
}

