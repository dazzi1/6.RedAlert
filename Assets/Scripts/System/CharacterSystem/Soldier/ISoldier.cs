using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoldierType {
	Rookie,
	Sergeant,
	Captain,
	Captive
}
//8.9.10.状态模式（有限状态机FSM）
public abstract class ISoldier : ICharacter
{

	protected SoldierFSMSystem mFSMSystem;

	public ISoldier() : base(){
		MakeFSM();
	}

	public override void UpdateFSMAI(List<ICharacter> targets) {
        if (mIsKilled)
        {
			return;
        }
		mFSMSystem.currentState.Reason(targets);
		mFSMSystem.currentState.Act(targets);
	}

	private void MakeFSM() {
		mFSMSystem = new SoldierFSMSystem();

		SoldierIdleState idleState = new SoldierIdleState(mFSMSystem,this);
		idleState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

		SoldierChaseState chaseState = new SoldierChaseState(mFSMSystem, this);
		chaseState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
		chaseState.AddTransition(SoldierTransition.CanAttack, SoldierStateID.Attack);

		SoldierAttackState attackState = new SoldierAttackState(mFSMSystem, this);
		attackState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
		attackState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

		mFSMSystem.AddState(idleState,chaseState,attackState);

	}

    public override void UnderAttack(int damage)
    {
		if (mIsKilled) return;
		base.UnderAttack(damage);
        if (mAttr.currentHP <= 0)
        {
			PlaySound();
			PlayEffect();
			Killed();
        }
    }
    public override void Killed()
    {
        base.Killed();
		GameFacade.Instance.NotifySubject(GameEventType.SoldierKilled);    }
    protected abstract void PlaySound();
	protected abstract void PlayEffect();

    public override void RunVisitor(ICharacterVisitor visitor)
    {
		visitor.VisitSoldier(this);
    }
}
