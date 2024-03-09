using System;
using Actions;
using Atomic.Behaviours;
using Atomic.Elements;
using DefaultNamespace.Items;
using DefaultNamespace.Physics;
using Mechanics;

namespace Components
{
    [Serializable]
    public class PickUpWeaponComponent : IEnable, IDisable, IDisposable
    {
        public AtomicEvent<IWeaponItem> pickUpEvent;
        public AtomicEvent<IWeaponItem, string> pickUpFailed;
        public PickUpWeaponAction pickUpAction;
        private PickUpWeaponMechanics pickUpWeaponMechanics;

        public void Compose(TriggerDispatcher triggerDispatcher)
        {
            pickUpAction.Compose(pickUpEvent, pickUpFailed);
            pickUpWeaponMechanics = new PickUpWeaponMechanics(triggerDispatcher, pickUpAction);
        }
        
        
        public void Dispose()
        {
            pickUpWeaponMechanics.Disable();
        }

        public void Enable()
        {
            pickUpWeaponMechanics.Enable();
        }

        public void Disable()
        {
            pickUpEvent?.Dispose();
        }
    }
}