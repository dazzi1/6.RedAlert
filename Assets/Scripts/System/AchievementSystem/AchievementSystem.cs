using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AchievementSystem : IGameSystem
{
    private int mEnemyKilledCount = 0;
    private int mSoldierKilledCount = 0;
    private int mMaxStageLv = 1;

    public override void Init()
    {
        base.Init();
        mFacade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKillObserverAchievement(this));
        mFacade.RegisterObserver(GameEventType.SoldierKilled, new SoldierKilledObserverAchievement(this));
        mFacade.RegisterObserver(GameEventType.NewStage, new NewStageObserverAchievement(this));
    }

    public void AddEnemyKilledCount(int number = 1) {
        mEnemyKilledCount += number;
    }
    public void AddSoldierKilledCount(int number = 1) {
        mSoldierKilledCount += number;
    }
    public void SetMaxStageLv(int stageLv) {
        if (stageLv > mMaxStageLv)
        {
            mMaxStageLv = stageLv;
        }
    }

    public AchievementMemento CreateMemento() {
        //PlayerPrefs.SetInt("EnemyKilledCount", mEnemyKilledCount);
        //PlayerPrefs.SetInt("SoldierKilledCount", mSoldierKilledCount);
        //PlayerPrefs.SetInt("MaxStageLv", mMaxStageLv);
        AchievementMemento memento = new AchievementMemento();
        memento.enemyKilledCount = mEnemyKilledCount;
        memento.soldierKilledCount = mSoldierKilledCount;
        memento.maxStageLv = mMaxStageLv;
        return memento;
    }
    public void SetMemento(AchievementMemento memento) {
        //mEnemyKilledCount = PlayerPrefs.GetInt("EnemyKilledCount");
        //mSoldierKilledCount = PlayerPrefs.GetInt("SoldierKilledCount");
        //mMaxStageLv = PlayerPrefs.GetInt("MaxStageLv");
        mEnemyKilledCount = memento.enemyKilledCount;
        mSoldierKilledCount = memento.soldierKilledCount;
        mMaxStageLv = memento.maxStageLv;
    }
}

