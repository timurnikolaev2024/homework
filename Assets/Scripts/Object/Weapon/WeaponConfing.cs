using System;
using Atomic.Objects;
using UnityEngine;

namespace Object.Weapon
{
    public abstract class WeaponConfing : ScriptableObject, IComparable<WeaponConfing>
    {
        [SerializeField] public int sortingOrder = 1;

        protected internal abstract IWeaponController instantiateWeaponController(
            IAtomicObject owner);
        
        public int CompareTo(WeaponConfing other)
        {
            return sortingOrder.CompareTo(other.sortingOrder);
        }
    }
}