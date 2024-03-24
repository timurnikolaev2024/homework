using System;
using Atomic.Elements;
using DefaultNamespace;

namespace Object.Weapon
{
    [Serializable]
    public sealed class IsWeaponAvailableFunction : IAtomicFunction<bool>
    {
        private IAtomicValue<WeaponObjectsLOL.Weapon> weapon;

        public void Compose(IAtomicValue<WeaponObjectsLOL.Weapon> weapon)
        {
            this.weapon = weapon;
        }

        public bool Invoke()
        {
            WeaponObjectsLOL.Weapon weapon = this.weapon.Value;
            if (weapon == null)
            {
                return false;
            }

            var isEndlessWeapon = !weapon.TryGet(WeaponAPI.Magazine, out WeaponMagazine magazine);
            if (isEndlessWeapon)
            {
                return true;
            }

            return magazine.IsNotEmpty();
        }
    }
}