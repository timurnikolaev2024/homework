using Atomic.Behaviours;
using Atomic.Elements;
using Sirenix.OdinInspector;

namespace Object.Weapon
{
    public sealed class WeaponBehaviourMechanics : IEnable, IDisable
    {
        private AtomicBehaviour owner;
        private IWeaponFactory weaponFactory;
        private AtomicVariable<WeaponObjectsLOL.Weapon> currentWeapon;

        [ShowInInspector, ReadOnly]
        private ILogic _currentController;

        public WeaponBehaviourMechanics()
        {
        }

        public WeaponBehaviourMechanics(
            IWeaponFactory factory,
            AtomicBehaviour owner,
            AtomicVariable<WeaponObjectsLOL.Weapon> currentWeapon
        )
        {
            this.owner = owner;
            this.weaponFactory = factory;
            this.currentWeapon = currentWeapon;
        }
        
        public void Compose(
            IWeaponFactory factory,
            AtomicBehaviour owner,
            AtomicVariable<WeaponObjectsLOL.Weapon> currentWeapon
        )
        {
            this.owner = owner;
            this.weaponFactory = factory;
            this.currentWeapon = currentWeapon;
        }

        public void SetOwner(AtomicBehaviour owner)
        {
            this.owner = owner;
        }
        
        public void SetFactory(IWeaponFactory factory)
        {
            this.weaponFactory = factory;
        }

        public void SetWeapon(AtomicVariable<WeaponObjectsLOL.Weapon> weapon)
        {
            this.currentWeapon = weapon;
        }

        public void Enable()
        {
            this.currentWeapon.Subscribe(this.OnWeaponChanged);
            this.OnWeaponChanged(this.currentWeapon.Value);
        }

        public void Disable()
        {
            this.currentWeapon.Unsubscribe(this.OnWeaponChanged);
        }

        private void OnWeaponChanged(WeaponObjectsLOL.Weapon weapon)
        {
            this.owner.RemoveLogic(_currentController);

            if (weapon == null)
            {
                return;
            }

            _currentController = this.weaponFactory.CreateController(weapon, this.owner);
            this.owner.AddLogic(_currentController);
        }
    }
}