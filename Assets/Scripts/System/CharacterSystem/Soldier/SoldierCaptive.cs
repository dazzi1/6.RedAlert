using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//22.适配器模式
public class SoldierCaptive : ISoldier
{
    private IEnemy mEnemy;

    public SoldierCaptive(IEnemy enemy) {
        mEnemy = enemy;
        ICharacterAttr attr = new SoldierAttr(enemy.attr.strategy, 1, enemy.attr.baseAttr);
        this.attr = attr;

        this.gameObject = mEnemy.gameObject;
        this.weapon = mEnemy.weapon;
    }

    protected override void PlaySound()
    {
        
    }

    protected override void PlayEffect()
    {
        mEnemy.PlayEffect();
    }

    
}

