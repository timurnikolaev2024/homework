using Atomic.Behaviours;
using Atomic.Elements;
using DefaultNamespace.Items;
using DefaultNamespace.Physics;
using UnityEngine;

namespace Mechanics
{
    public class PickUpWeaponMechanics : IEnable, IDisable
    {
        private readonly TriggerDispatcher trigger;
        private readonly IAtomicAction<IWeaponItem> pickUpAction;

        public PickUpWeaponMechanics(TriggerDispatcher trigger, IAtomicAction<IWeaponItem> pickUpAction)
        {
            this.trigger = trigger;
            this.pickUpAction = pickUpAction;
        }

        public void Enable()
        {
            this.trigger.OnEnter += this.OnTriggerEntered;
        }

        public void Disable()
        {
            this.trigger.OnEnter -= this.OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider collider)
        {
            if (collider.TryGetComponent(out IWeaponItem item))
            {
                this.pickUpAction.Invoke(item);
            }
        }
    }
}