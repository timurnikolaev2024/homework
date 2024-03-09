using System;
using Atomic.Elements;
using Atomic.Objects;
using Object.Weapon;
using UnityEngine;

namespace DefaultNamespace.Items
{
    public class WeaponItem : AtomicObject, IWeaponItem
    {
        public WeaponConfing Config { get { return config; } }

        public IAtomicAction PickUpAction { get { return pickUpAction; } }

        [SerializeField] private WeaponConfing config;
        [SerializeField] private AtomicAction pickUpAction;

        private void Awake()
        {
            Compose();
        }

        public override void Compose()
        {
            base.Compose();
            pickUpAction.Compose(() => Destroy(gameObject));
        }
    }
}