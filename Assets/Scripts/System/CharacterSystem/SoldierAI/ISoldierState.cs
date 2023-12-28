using System.Collections.Generic;
using UnityEngine;

public enum SoldierTransition {
    NullTransition = 0,
    SeeEnemy,
    NoEnemy,
    CanAttack
}

public enum SoldierStateID {
    NullState,
    Idle,
    Chase,
    Attack
}

public abstract class ISoldierState
{
    protected Dictionary<SoldierTransition, SoldierStateID> mMap = new Dictionary<SoldierTransition, SoldierStateID>();
    protected SoldierStateID mStateID;
    protected ICharacter mCharacter;
    protected SoldierFSMSystem mFSM;

    public ISoldierState(SoldierFSMSystem fsm,ICharacter character) {
        mFSM = fsm;
        mCharacter = character;
    }

    public SoldierStateID stateID { get { return mStateID; } }

    public void AddTransition(SoldierTransition trans, SoldierStateID id)
    {
        if (trans == SoldierTransition.NullTransition)
        {
            Debug.LogError("SoldierState Error: trans不能为空");
            return;
        }
        if (id == SoldierStateID.NullState)
        {
            Debug.LogError("SoldierState Error: id状态ID不能为空");
            return;
        }
        if (mMap.ContainsKey(trans))
        {
            Debug.LogError("SoldierState Error:" + trans + "已经添加上了");
            return;
        }
        mMap.Add(trans, id);
    }
    public void DeleteTransition(SoldierTransition trans)
    {
        if (mMap.ContainsKey(trans) == false)
        {
            Debug.LogError("删除转换条件的时候，转换条件：[" + trans + "]不存在");
            return;
        }
        mMap.Remove(trans);
    }

    public SoldierStateID GetOutPutState(SoldierTransition trans)
    {
        if (mMap.ContainsKey(trans) == false)
        {
            return SoldierStateID.NullState;
        }
        else
        {
            return mMap[trans];
        }
    }

    public virtual void DoBeforeEntering(){ }
    public virtual void DoBeforeLeaving(){ }

    public abstract void Reason(List<ICharacter> targets);
    public abstract void Act(List<ICharacter> targets);
}
