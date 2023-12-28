using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class SoldierCamp : ICamp
{
    const int MAX_LV = 4;
    private int mLv = 1;
    private WeaponType mWeaponType = WeaponType.Gun;
    public SoldierCamp(GameObject gameObject, string name, string icon,
        SoldierType soldierType, Vector3 position, float trainTime, WeaponType weaponType = WeaponType.Gun, int lv = 1) :
        base(gameObject, name, icon, soldierType, position, trainTime)
    {
        mLv = lv;
        mWeaponType = weaponType;
        energyCostStrategy = new SoldierEnergyCostStrategy();
        UpdateEnergyCost();
    }

    public override int lv { get { return mLv; } }

    public override WeaponType weaponType { get { return mWeaponType; } }

    public override int energyCostCampUpgrade
    {
        get
        {
            if (mLv == MAX_LV)
            {
                return -1;
            }
            else
            {
                return mEnergyCostCampUpgrade;
            } 
        } 
    }

    public override int energyCostWeaponUpgrade {
        get
        {
            if (mWeaponType +1 == WeaponType.MAX)
            {
                return -1;
            }
            else
            {
                return mEnergyCostWeaponUpgrade;
            }
        }
    }

    public override int energyCostTrain {
        get {
            return mEnergyCostTrain;
        }
    }

    public override void Train()
    {
        //添加训练命令
        TrainSoldierCommand cmd = new TrainSoldierCommand(mSoldierType, mWeaponType, mPosition, mLv);
        mCommands.Add(cmd);
    }

    protected override void UpdateEnergyCost()
    {
        mEnergyCostCampUpgrade = energyCostStrategy.GetCampUpgradeCost(mSoldierType, mLv);
        mEnergyCostWeaponUpgrade = energyCostStrategy.GetWeaponUpgradeCost(mWeaponType);
        mEnergyCostTrain = energyCostStrategy.GetSoldierTrainCost(mSoldierType, mLv);
    }

    public override void UpgradeCamp()
    {
        mLv++;
        UpdateEnergyCost();
    }

    public override void UpgradeWeapon()
    {
        mWeaponType = mWeaponType + 1;
        UpdateEnergyCost();
    }

    
}

