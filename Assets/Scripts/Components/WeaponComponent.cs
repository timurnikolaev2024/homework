using System;
using Atomic.Behaviours;
using Atomic.Elements;
using Atomic.Objects;
using DefaultNamespace;
using Object.Weapon;
using Object.Weapon.WeaponObjectsLOL;
using UnityEngine;

namespace Components
{
    public class WeaponComponent : MonoBehaviour, IEnable, IDisable, IDisposable
    {
[SerializeField]
        private Transform weaponTransform;

        [Get(WeaponAPI.CurrentWeapon)]
        public AtomicVariable<Weapon> currentWeapon;

        [Get(WeaponAPI.WeaponStorage)]
        public WeaponsStorage weaponsStorage;
        public WeaponProvider weaponProvider;

        public IsWeaponAvailableFunction isCurrentWeaponAvailable;
        public CanFireWeaponFunction isCurrentWeaponReady;

        [Get(WeaponAPI.SwitchWeaponAction)]
        //public SwitchWeaponAction switchWeaponAction;
        public AtomicEvent<Weapon> switchWeaponEvent;

        [Get(WeaponAPI.AddWeaponAmmoAction)]
        public AddWeaponChargesAction addWeaponChargesAction;

        private readonly WeaponBehaviourMechanics behaviourMechanics = new();
        //private SelectNextWeaponWhenPreviousEndedMechanics autoSwitchMechanics;

        //[Inject]
        public void Construct(IWeaponFactory weaponFactory)
        {
            this.weaponProvider.SetFactory(weaponFactory);
            this.behaviourMechanics.SetFactory(weaponFactory);
        }

        public void Compose(AtomicBehaviour owner)
        {
            //WeaponFactory factory = new WeaponFactory();
            this.isCurrentWeaponReady.Compose(this.currentWeapon);
            this.isCurrentWeaponAvailable.Compose(this.currentWeapon);

            this.addWeaponChargesAction.Compose(this.weaponProvider);
            //this.switchWeaponAction.Compose(this.weaponsStorage, this.currentWeapon, this.switchWeaponEvent);

            //this.autoSwitchMechanics = new SelectNextWeaponWhenPreviousEndedMechanics(
            //    this.currentWeapon, this.weaponsStorage, this.switchWeaponAction
            //);

            this.behaviourMechanics.Let(it =>
            {
                it.SetOwner(owner);
                it.SetWeapon(this.currentWeapon);
            });

            Debug.Log("timur ? " + (weaponProvider == null));
            weaponProvider = new WeaponProvider();
            this.weaponProvider.Let(it =>
            {
                it.SetStorage(this.weaponsStorage);
                it.SetParent(this.weaponTransform);
                it.SetOwner(owner);
            });
            weaponProvider.SetFactory(FindObjectOfType<WeaponFactory>());
            weaponProvider.SetFactory(FindObjectOfType<WeaponFactory>());
        }

        public void Enable()
        {
            //this.autoSwitchMechanics.Enable();
            this.behaviourMechanics.Enable();
        }

        public void Disable()
        {
            //this.autoSwitchMechanics.Disable();
            this.behaviourMechanics.Disable();
        }

        public void Dispose()
        {
            this.currentWeapon?.Dispose();
        }
    }
}