using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//13.享元模式
public class AttrFactory : IAttrFactory
{
    private Dictionary<Type, CharacterBaseAttr> mCharacterBaseAttrDict;
    private Dictionary<WeaponType, WeaponBaseAttr> mWeaponBaseAttrDict;

    public AttrFactory() {
        InitCharacterBaseAttr();
        InitWeaponBaseAttr();
    }

    private void InitCharacterBaseAttr()
    {
        mCharacterBaseAttrDict = new Dictionary<Type, CharacterBaseAttr>();
        mCharacterBaseAttrDict.Add(typeof(SoldierRookie), new CharacterBaseAttr("新手士兵",
            80, 2.5f, "RookieIcon", "Soldier2", 0));
        mCharacterBaseAttrDict.Add(typeof(SoldierSergeant), new CharacterBaseAttr("中士士兵",
            90, 3, "SergeantIcon", "Soldier3", 0));
        mCharacterBaseAttrDict.Add(typeof(SoldierCaptain), new CharacterBaseAttr("上尉士兵",
            100, 3, "CaptainIcon", "Soldier1", 0));

        mCharacterBaseAttrDict.Add(typeof(EnemyElf), new CharacterBaseAttr("小精灵",
            100, 3, "ElfIcon", "Enemy1", 0.2f));
        mCharacterBaseAttrDict.Add(typeof(EnemyOgre), new CharacterBaseAttr("怪物",
            120, 2, "OgreIcon", "Enemy2", 0.3f));
        mCharacterBaseAttrDict.Add(typeof(EnemyTroll), new CharacterBaseAttr("巨魔",
            200, 1, "TrollIcon", "Enemy3", 0.4f));
    }

    private void InitWeaponBaseAttr() {
        mWeaponBaseAttrDict = new Dictionary<WeaponType, WeaponBaseAttr>();
        mWeaponBaseAttrDict.Add(WeaponType.Gun, new WeaponBaseAttr("手枪", 20, 5, "WeaponGun"));
        mWeaponBaseAttrDict.Add(WeaponType.Rifle, new WeaponBaseAttr("长枪", 30, 7, "WeaponRifle"));
        mWeaponBaseAttrDict.Add(WeaponType.Rocket, new WeaponBaseAttr("火箭", 40, 8, "WeaponRocket"));
    }

    public CharacterBaseAttr GetCharacterBaseAttr(Type t)
    {
        if (mCharacterBaseAttrDict.ContainsKey(t) == false)
        {
            Debug.LogError("无法根据类型：" + t + "得到角色基础属性（GetCharacterBaseAttr）");
            return null;
        }
        return mCharacterBaseAttrDict[t];
    }

    public WeaponBaseAttr GetWeaponBaseAttr(WeaponType weaponType)
    {
        if (mWeaponBaseAttrDict.ContainsKey(weaponType) == false)
        {
            Debug.LogError("无法根据类型：" + weaponType + "得到武器基础属性");
            return null;
        }
        return mWeaponBaseAttrDict[weaponType];
    }
}

