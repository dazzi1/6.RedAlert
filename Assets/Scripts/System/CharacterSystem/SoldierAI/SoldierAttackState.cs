using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class SoldierAttackState : ISoldierState
{
    public SoldierAttackState(SoldierFSMSystem fsm,ICharacter c) : base(fsm,c) {
        mStateID = SoldierStateID.Attack;
        mAttackTimer = mAttackTime;
    }

    private float mAttackTime = 1;
    private float mAttackTimer = 1;

    public override void Act(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0)
        {
            return;
        }
        mAttackTimer += Time.deltaTime;
        if (mAttackTimer >= mAttackTime)
        {
            mCharacter.Attack(targets[0]);
            mAttackTimer = 0;
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0)
        {
            mFSM.PerformTransition(SoldierTransition.NoEnemy);return;
        }
        float distance = Vector3.Distance(mCharacter.position, targets[0].position);
        if (distance > mCharacter.atkRange)
        {
            mFSM.PerformTransition(SoldierTransition.SeeEnemy);
        }
    }
}

