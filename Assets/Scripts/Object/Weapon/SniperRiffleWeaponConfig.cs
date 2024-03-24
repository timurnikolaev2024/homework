using Atomic.Objects;
using Object.Weapon.WeaponObjectsLOL;
using UnityEngine;

namespace Object.Weapon
{
    [CreateAssetMenu(
        fileName = "SniperRiffleWeaponConfig",
        menuName = "Gameplay/Weapons/New SniperRiffleWeaponConfig"
    )]
    public class SniperRiffleWeaponConfig : WeaponConfing
    {
        public Bullet bulletPrefab;
        public int magazineCapacity = 10;
        protected internal override IWeaponController instantiateWeaponController(IAtomicObject owner, WeaponObjectsLOL.Weapon weapon)
        {
            return new SniperRiffleWeaponController(owner, weapon as SniperRiffle_Weapon, this);
        }
    }
}