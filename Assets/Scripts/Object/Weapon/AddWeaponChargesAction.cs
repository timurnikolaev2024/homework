using System;
using Atomic.Elements;
using DefaultNamespace;
using Sirenix.OdinInspector;

namespace Object.Weapon
{
    [Serializable]
    public sealed class AddWeaponChargesAction : IAtomicAction<WeaponConfing, int>
    {
        private IWeaponProvider weaponProvider;

        public void Compose(IWeaponProvider weaponProvider)
        {
            this.weaponProvider = weaponProvider;
        }

        public void Invoke(WeaponConfing args1, int args2)
        {
            WeaponObjectsLOL.Weapon weapon = this.weaponProvider.Provide(args1);
            WeaponMagazine weaponMagazine = weapon.Get<WeaponMagazine>(WeaponAPI.Magazine);
            
            if (weaponMagazine != null)
            {
                weaponMagazine.AddCharges(args2);
            }
        }
    }
}