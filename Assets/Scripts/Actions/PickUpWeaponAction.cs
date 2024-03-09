using System;
using Atomic.Elements;
using DefaultNamespace.Items;

namespace Actions
{
    [Serializable]
    public class PickUpWeaponAction : IAtomicAction<IWeaponItem>
    {
        //private IWeaponProvider weaponProvider;
        private IAtomicEvent<IWeaponItem> pickUpEvent;
        private IAtomicEvent<IWeaponItem, string> pickUpFailed;

        public void Compose(
            //IWeaponProvider weaponProvider,
            IAtomicEvent<IWeaponItem> pickUpEvent,
            IAtomicEvent<IWeaponItem, string> pickUpFailed
        )
        {
            //this.weaponProvider = weaponProvider;
            this.pickUpEvent = pickUpEvent;
            this.pickUpFailed = pickUpFailed;
        }

        public void Invoke(IWeaponItem item)
        {
            item.PickUpAction.Invoke();
            this.pickUpEvent?.Invoke(item);
        }
    }
}