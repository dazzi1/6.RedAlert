using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponLaser : IWeapon
{
    public WeaponLaser(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject) { }

    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        throw new NotImplementedException();
    }

    protected override void PlaySound()
    {
        throw new NotImplementedException();
    }

    protected override void SetEffectDisplayTime()
    {
        throw new NotImplementedException();
    }
}

