using Atomic.Objects;
using UnityEngine;

namespace Object.Weapon
{
    [CreateAssetMenu(
        fileName = "SniperRiffleWeaponConfig",
        menuName = "Gameplay/Weapons/New SniperRiffleWeaponConfig"
    )]
    public class SniperRiffleWeaponConfig : WeaponConfing
    {
        protected internal override IWeaponController instantiateWeaponController(IAtomicObject owner)
        {
            throw new System.NotImplementedException();
        }
    }
}