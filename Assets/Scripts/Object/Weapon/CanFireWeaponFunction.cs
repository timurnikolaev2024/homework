using System;
using Atomic.Elements;
using Sirenix.OdinInspector;

namespace Object.Weapon
{
    [Serializable]
    public sealed class CanFireWeaponFunction : IAtomicFunction<bool>
    {
        private IAtomicValue<WeaponObjectsLOL.Weapon> weapon;

        public void Compose(IAtomicValue<WeaponObjectsLOL.Weapon> weapon)
        {
            this.weapon = weapon;
        }
        
        [Button]
        public bool Invoke()
        {
            WeaponObjectsLOL.Weapon weapon = this.weapon.Value;
            
            if (weapon == null)
            {
                return false;
            }
                
            return weapon.CanFire.Value;
        }
    }
}