using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class SoldierFactory : ICharacterFactory
{
    public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1)where T:ICharacter,new()
    {
        ICharacter character = new T();

        ICharacterBuilder builder = new SoldierBuilder(character, typeof(T), weaponType, spawnPosition, lv);

        //工程师方法进行组装
        return CharacterBuilderDirector.Construct(builder);
    }
}

