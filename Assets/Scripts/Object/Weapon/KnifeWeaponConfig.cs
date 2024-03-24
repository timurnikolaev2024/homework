using Atomic.Objects;
using UnityEngine;

namespace Object.Weapon
{
    [CreateAssetMenu(
        fileName = "KnifeWeaponConfig",
        menuName = "Gameplay/Weapons/New KnifeWeaponConfig"
    )]
    public class KnifeWeaponConfig : WeaponConfing
    {

        protected internal override IWeaponController instantiateWeaponController(IAtomicObject owner, WeaponObjectsLOL.Weapon weapon)
        {
            throw new System.NotImplementedException();
        }
    }
}