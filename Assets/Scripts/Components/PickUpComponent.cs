using System;
using Atomic.Behaviours;
using Atomic.Objects;
using DefaultNamespace.Physics;

namespace Components
{
    [Serializable]
    public class PickUpComponent : IEnable, IDisable, IDisposable
    {
        [Section] public PickUpWeaponComponent weaponComponent;

        public void Compose(TriggerDispatcher trigger)
        {
            weaponComponent.Compose(trigger);
        }
        public void Dispose()
        {
            weaponComponent?.Dispose();
        }

        public void Enable()
        {
            weaponComponent.Enable();
        }

        public void Disable()
        {
            weaponComponent.Disable();
        }
    }
}