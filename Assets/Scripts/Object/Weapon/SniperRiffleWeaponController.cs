using Atomic.Behaviours;
using Atomic.Objects;
using Object.Weapon.WeaponObjectsLOL;

namespace Object.Weapon
{
    //TO DO: add animator dispatcher to owner
    public class SniperRiffleWeaponController : IWeaponController, IEnable, IDisable
    {
        private readonly IAtomicObject owner;
        private readonly SniperRiffle_Weapon weapon;
        //private readonly AnimatorDispatcher ownerAnimator;
        private readonly SniperRiffleWeaponConfig config;
        public SniperRiffleWeaponController(IAtomicObject owner, SniperRiffle_Weapon weapon,
            SniperRiffleWeaponConfig config)
        {
            this.owner = owner;
            this.weapon = weapon;
            this.config = config;
            //this.ownerAnimator = owner.Get<AnimatorDispatcher>(AnimatorAPI.Dispatcher);
        }

        public void Enable()
        {
            //ownerAnimator.OnAnimEvent =+ OnAnimEvent;
            weapon.FireEvent.Subscribe(OnFireEvent);
        }

        private void OnFireEvent()
        {
            throw new System.NotImplementedException();
        }

        public void Disable()
        {
            //unsub
            weapon.FireEvent.Unsubscribe(OnFireEvent);
        }
    }
}