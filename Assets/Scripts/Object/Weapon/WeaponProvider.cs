using Atomic.Objects;
using UnityEngine;

namespace Object.Weapon
{
    public class WeaponProvider : IWeaponProvider
    {
        private WeaponsStorage storage;
        private IWeaponFactory factory;
        private Transform parent;
        private IAtomicObject owner;

        public void Compose(
            WeaponsStorage storage,
            IWeaponFactory factory,
            Transform parent,
            IAtomicObject owner
        )
        {
            this.storage = storage;
            this.factory = factory;
            this.parent = parent;
            this.owner = owner;
        }

        public WeaponObjectsLOL.Weapon Provide(WeaponConfing config)
        {
            Debug.Log("timur provide...");
            if (this.storage.TryGetWeapon(config, out WeaponObjectsLOL.Weapon weapon))
            {
                return weapon;
            }

            weapon = this.factory.CreateWeapon(config, this.parent, this.owner);
            this.storage.AddWeapon(weapon);
            return weapon;
        }
        
        public void SetStorage(WeaponsStorage storage)
        {
            Debug.Log("timur set storage...");
            this.storage = storage;
        }

        public void SetFactory(IWeaponFactory factory)
        {
            this.factory = factory;
        }

        public void SetParent(Transform parent)
        {
            Debug.Log("timur set parent...");
            this.parent = parent;
        }

        public void SetOwner(IAtomicObject owner)
        {
            Debug.Log("timur set owner...");
            this.owner = owner;
        }
    }
    public interface IWeaponProvider
    {
        WeaponObjectsLOL.Weapon Provide(WeaponConfing config);
    }
}