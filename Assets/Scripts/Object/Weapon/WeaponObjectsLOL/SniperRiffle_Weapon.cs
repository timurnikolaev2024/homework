using System;
using Atomic.Elements;
using Atomic.Objects;
using Controllers;
using DefaultNamespace;
using UnityEngine;

namespace Object.Weapon.WeaponObjectsLOL
{
    public class SniperRiffle_Weapon : Weapon
    {
        public override WeaponConfing Config => config;
        public override IAtomicValue<bool> CanFire { get; }

        [Get(WeaponAPI.FireAction)] public IAtomicAction FireAction => core.fireAction;
        [Get(WeaponAPI.FireEvent)] public IAtomicEvent FireEvent => core.fireEvent;

        [Section] [SerializeField] private SniperRiffleWeaponConfig config;

        [Section] [SerializeField] private Core core;

        private void Awake()
        {
            core.bulletPool = FindObjectOfType<BulletPool>();
        }

        public void Constuct(IBulletPool bulletPool)
        {
            //core.bulletPool = FindObjectOfType<BulletPool>();
        }

        public override void Compose()
        {
            core.bulletPool = FindObjectOfType<BulletPool>();
            base.Compose();
            core.Compose(config, this);
        }

        [Serializable]
        private sealed class Core
        {
            [Header("Fire")] public AtomicFunction<bool> fireCondition;
            public AtomicAction fireAction;
            public AtomicEvent fireEvent;
            public Transform firePoint;

            [Header("Bullet")] public IBulletPool bulletPool;

            [Header("Ammo")] [Get(WeaponAPI.Magazine)]
            public WeaponMagazine magazine;

            public FireSpreadBulletAction bulletAction;

            public void Compose(SniperRiffleWeaponConfig config, SniperRiffle_Weapon weapon)
            {
                ComposeData(config);
                ComposeCondition();
                ComposeActions();
            }

            private void ComposeActions()
            {
                Debug.Log($"timurF {bulletAction == null} {bulletPool == null} {firePoint == null}");
                bulletAction = new FireSpreadBulletAction();
                bulletAction.Compose(bulletPool, firePoint);
                fireAction.Compose(() =>
                {
                    if (fireCondition.Value)
                    {
                        magazine.SpendCharge();
                        bulletAction?.Invoke();
                        fireEvent?.Invoke();
                    }
                });
            }

            private void ComposeCondition()
            {
                fireCondition.Compose(() => magazine.Current > 0);
            }

            private void ComposeData(SniperRiffleWeaponConfig config)
            {
                magazine.Max = config.magazineCapacity;
            }
        }

        [Serializable]
        private sealed class View
        {
            
        }
    }
}