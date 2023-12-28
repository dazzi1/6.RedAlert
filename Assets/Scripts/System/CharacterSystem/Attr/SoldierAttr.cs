using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class SoldierAttr :ICharacterAttr
{
    public SoldierAttr(IAttrStrategy strategy,int lv, CharacterBaseAttr baseAttr) : base(strategy,lv, baseAttr) { }
}

