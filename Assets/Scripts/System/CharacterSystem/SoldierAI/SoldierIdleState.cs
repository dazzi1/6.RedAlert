using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class SoldierIdleState : ISoldierState
{
    public SoldierIdleState(SoldierFSMSystem fsm, ICharacter c) : base(fsm, c)
    {
        mStateID = SoldierStateID.Idle; }

    public override void Act(List<ICharacter> targets)
    {
        mCharacter.PlayAnim("stand");
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets!=null&&targets.Count > 0)
        {
            mFSM.PerformTransition(SoldierTransition.SeeEnemy);
        }
    }
}

