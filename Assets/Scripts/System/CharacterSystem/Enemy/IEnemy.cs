using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType {
    Elf,
    Ogre,
    Troll
}
//8.9.10.状态模式（有限状态机FSM）
public abstract class IEnemy : ICharacter
{
    protected EnemyFSMSystem mFSMSystem;

    public IEnemy() {
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
        mFSMSystem = new EnemyFSMSystem();

        EnemyChaseState chaseState = new EnemyChaseState(mFSMSystem, this);
        chaseState.AddTransition(EnemyTransition.CanAttack, EnemyStateID.Attack);

        EnemyAttackState attackState = new EnemyAttackState(mFSMSystem, this);
        attackState.AddTransition(EnemyTransition.LostSoldier, EnemyStateID.Chase);

        mFSMSystem.AddState(chaseState, attackState);
    }

    public override void UnderAttack(int damage)
    {
        if (mIsKilled) return;
        base.UnderAttack(damage);
        PlayEffect();
        if (mAttr.currentHP <= 0)
        {
            Killed();
        }
    }

    public abstract void PlayEffect();

    public override void Killed()
    {
        base.Killed();
        GameFacade.Instance.NotifySubject(GameEventType.EnemyKilled);
    }

    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.VisitEnemy(this);
    }
}
