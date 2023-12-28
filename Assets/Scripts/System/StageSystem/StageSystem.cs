using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//18.责任链模式
public class StageSystem : IGameSystem
{
    int mLv = 1;
    List<Vector3> mPosList;
    IStageHandler mRootHandler;
    Vector3 mTargetPosition;
    int mCountOfEnemyKilled = 0;

    public override void Init()
    {
        base.Init();
        InitPosition();
        InitStageChain();
        mFacade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKilledObserverStageSystem(this));
    }

    public override void Update()
    {
        base.Update();
        mRootHandler.Handle(mLv);
    }

    private void InitPosition()
    {
        mPosList = new List<Vector3>();
        int i = 1;
        while (true)
        {
            GameObject go = GameObject.Find("Position" + i);
            if (go!=null)
            {
                i++;
                mPosList.Add(go.transform.position);
                go.SetActive(false);
            }
            else
            {
                break;
            }
        }
        GameObject targetPos = GameObject.Find("TargetPosition");
        //targetPos.SetActive(false);
        mTargetPosition = targetPos.transform.position;
    }
    private Vector3 GetRandomPos() {
        return mPosList[UnityEngine.Random.Range(0, mPosList.Count)];
    }
    private void InitStageChain() {
        int lv = 1;
        NormalStageHandler handler1 = new NormalStageHandler(this, lv++, 3, EnemyType.Elf, WeaponType.Gun, 3, GetRandomPos());
        NormalStageHandler handler2 = new NormalStageHandler(this, lv++, 6, EnemyType.Elf, WeaponType.Rifle, 3, GetRandomPos());
        NormalStageHandler handler3 = new NormalStageHandler(this, lv++, 9, EnemyType.Elf, WeaponType.Rocket, 3, GetRandomPos());
        NormalStageHandler handler4 = new NormalStageHandler(this, lv++, 13, EnemyType.Ogre, WeaponType.Gun, 4, GetRandomPos());
        NormalStageHandler handler5 = new NormalStageHandler(this, lv++, 17, EnemyType.Ogre, WeaponType.Rifle, 4, GetRandomPos());
        NormalStageHandler handler6 = new NormalStageHandler(this, lv++, 21, EnemyType.Ogre, WeaponType.Rocket, 4, GetRandomPos());
        NormalStageHandler handler7 = new NormalStageHandler(this, lv++, 26, EnemyType.Troll, WeaponType.Gun, 5, GetRandomPos());
        NormalStageHandler handler8 = new NormalStageHandler(this, lv++, 31, EnemyType.Troll, WeaponType.Rifle, 5, GetRandomPos());
        NormalStageHandler handler9 = new NormalStageHandler(this, lv++, 36, EnemyType.Troll, WeaponType.Rocket, 5, GetRandomPos());

        handler1.SetNextHandler(handler2)
            .SetNextHandler(handler3)
            .SetNextHandler(handler4)
            .SetNextHandler(handler5)
            .SetNextHandler(handler6)
            .SetNextHandler(handler7)
            .SetNextHandler(handler8)
            .SetNextHandler(handler9);
        mRootHandler = handler1;
    }

    public int GetCountOfEnemyKilled() {
        return mCountOfEnemyKilled;
    }

    public int countOfEnemyKilled {
        set {
            mCountOfEnemyKilled = value;
        }
    }

    public void EnterNextStage() {
        mLv++;
        mFacade.NotifySubject(GameEventType.NewStage);
    }

    public Vector3 targetPosition {
        get { return mTargetPosition; }
    }
}

