using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//12.建造者模式
public class CharacterBuilderDirector
{
    public static ICharacter Construct(ICharacterBuilder builder) {
        builder.AddCharacterAttr();
        builder.AddGameObject();
        builder.AddWeapon();
        builder.AddInCharacterSystem();
        return builder.GetResult();
    }
}

