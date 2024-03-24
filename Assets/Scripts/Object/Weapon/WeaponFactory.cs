using System;
using Atomic.Objects;
using UnityEngine;

namespace Object.Weapon
{
    [Serializable]
    public class WeaponFactory : MonoBehaviour, IWeaponFactory
    {
        public WeaponObjectsLOL.Weapon CreateWeapon(WeaponConfing config, Transform parent = null, IAtomicObject owner = null)
        {
            WeaponObjectsLOL.Weapon weapon = Instantiate(config.weaponPrefab, parent);
            weapon.Compose();
            
            Transform transform = weapon.transform;
            transform.localPosition = config.weaponTransformData.position;
            transform.localRotation = config.weaponTransformData.rotation;
            transform.localScale = config.weaponTransformData.scale;

            weapon.Owner.Value = owner;
            
            return weapon;
        }

        public IWeaponController CreateController(WeaponObjectsLOL.Weapon weapon, IAtomicObject owner)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IWeaponFactory
    {
        WeaponObjectsLOL.Weapon CreateWeapon(WeaponConfing config, Transform parent = null, IAtomicObject owner = null);
        
        IWeaponController CreateController(WeaponObjectsLOL.Weapon weapon, IAtomicObject owner);
    }
}