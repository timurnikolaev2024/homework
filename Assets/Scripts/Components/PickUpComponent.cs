using System;
using Atomic.Behaviours;
using Atomic.Objects;
using DefaultNamespace.Physics;

namespace Components
{
    [Serializable]
    public class PickUpComponent : IEnable, IDisable, IDisposable
    {
        [Section] public PickUpWeaponComponent pickUpWeaponComponent;

        public void Compose(WeaponComponent weaponComponent, TriggerDispatcher trigger)
        {
            pickUpWeaponComponent.Compose(weaponComponent, trigger);
        }
        public void Dispose()
        {
            pickUpWeaponComponent?.Dispose();
        }

        public void Enable()
        {
            pickUpWeaponComponent.Enable();
        }

        public void Disable()
        {
            pickUpWeaponComponent.Disable();
        }
    }
}