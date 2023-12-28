using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class EnemyBuilder : ICharacterBuilder
{
    public EnemyBuilder(ICharacter character, System.Type t, WeaponType weaponType, Vector3 spawnPosition, int lv) : 
        base(character, t, weaponType, spawnPosition, lv)
    {

    }

    public override void AddCharacterAttr()
    {
        CharacterBaseAttr baseAttr = FactoryManager.attrFactory.GetCharacterBaseAttr(mT);
        mPrefabName = baseAttr.prefabName;
        ICharacterAttr attr = new EnemyAttr(new EnemyAttrStrategy(), mLv, baseAttr);
        mCharacter.attr = attr;
    }

    public override void AddGameObject()
    {
        GameObject characterGO = FactoryManager.assetFactory.LoadEnemy(mPrefabName);
        characterGO.transform.position = mSpawnPosition;
        mCharacter.gameObject = characterGO;
    }

    public override void AddInCharacterSystem()
    {
        GameFacade.Instance.AddEnemy(mCharacter as IEnemy);
    }

    public override void AddWeapon()
    {
        IWeapon weapon = FactoryManager.weaponFactory.CreateWeapon(mWeaponType);
        mCharacter.weapon = weapon;
    }

    public override ICharacter GetResult()
    {
        return mCharacter;
    }
}

