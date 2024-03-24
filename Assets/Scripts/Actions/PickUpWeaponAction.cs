using System;
using Atomic.Elements;
using DefaultNamespace;
using DefaultNamespace.Items;
using Object.Weapon;
using Object.Weapon.WeaponObjectsLOL;
using UnityEngine;

namespace Actions
{
    [Serializable]
    public class PickUpWeaponAction : IAtomicAction<IWeaponItem>
    {
        private IWeaponProvider weaponProvider;
        private IAtomicEvent<IWeaponItem> pickUpEvent;
        private IAtomicEvent<IWeaponItem, string> pickUpFailed;

        public void Compose(
            IWeaponProvider weaponProvider,
            IAtomicEvent<IWeaponItem> pickUpEvent,
            IAtomicEvent<IWeaponItem, string> pickUpFailed
        )
        {
            this.weaponProvider = weaponProvider;
            Debug.Log("timur composssse" + (weaponProvider == null));
            this.pickUpEvent = pickUpEvent;
            this.pickUpFailed = pickUpFailed;
        }

        public void Invoke(IWeaponItem item)
        {
            WeaponConfing config = item.Config;
            Debug.Log("timur ??? " + (weaponProvider == null));
            Weapon weapon = this.weaponProvider.Provide(config);
            WeaponMagazine magazine = weapon.Get<WeaponMagazine>(WeaponAPI.Magazine);
            
            
            item.PickUpAction.Invoke();
            this.pickUpEvent?.Invoke(item);
        }
    }
}