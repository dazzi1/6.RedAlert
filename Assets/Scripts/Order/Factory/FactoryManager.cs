using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


//11.工厂模式
public static class FactoryManager
{
    private static IAssetFactory mAssetFactory = null;
    private static ICharacterFactory mSoldierFactory = null;
    private static ICharacterFactory mEnemyFactory = null;
    private static IWeaponFactory mWeaponFactory = null;
    private static IAttrFactory mAttrFactory = null;

    public static IAttrFactory attrFactory {
        get {
            if (mAttrFactory == null)
            {
                mAttrFactory = new AttrFactory();
            }
            return mAttrFactory;
        }
    }

    public static IAssetFactory assetFactory {
        get {
            if (mAssetFactory == null)
            {
                //mAssetFactory = new ResourcesAssetFactory();
                mAssetFactory = new ResoutcesAssetProxyFactory();
            }
            return mAssetFactory;
        }
    }
    public static ICharacterFactory soldierFactory {
        get {
            if (mSoldierFactory == null)
            {
                mSoldierFactory = new SoldierFactory();
            }
            return mSoldierFactory;
        }
    }
    public static ICharacterFactory enemyFactory {
        get {
            if (mEnemyFactory == null)
            {
                mEnemyFactory = new EnemyFactory();
            }
            return mEnemyFactory;
        }
    }
    public static IWeaponFactory weaponFactory {
        get {
            if (mWeaponFactory == null)
            {
                mWeaponFactory = new WeaponFactory();
            }
            return mWeaponFactory;
        }
    }

}

