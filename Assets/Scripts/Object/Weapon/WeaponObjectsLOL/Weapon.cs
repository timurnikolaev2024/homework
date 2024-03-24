using System;
using Atomic.Elements;
using Atomic.Objects;
using DefaultNamespace;
using UnityEngine;

namespace Object.Weapon.WeaponObjectsLOL
{
    [Is(ObjectType.Weapon)]
    public abstract class Weapon : AtomicObject, IComparable<Weapon>
    {
        [Get(WeaponAPI.Config)] public abstract WeaponConfing Config { get; }
        [Get(WeaponAPI.CanFire)] public abstract IAtomicValue<bool> CanFire { get; }
        
        //[Get(CommonAPI.Owner)]
        public IAtomicVariable<IAtomicObject> Owner => this.owner;
        
        [Header("Owner")]
        [SerializeField]
        private AtomicVariable<IAtomicObject> owner;
        
        public int CompareTo(Weapon other)
        {
            return Config.CompareTo(other.Config);
        }
    }
}