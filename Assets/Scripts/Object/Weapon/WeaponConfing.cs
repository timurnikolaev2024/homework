using System;
using Atomic.Objects;
using UnityEngine;
using UnityEngine.Serialization;

namespace Object.Weapon
{
    public abstract class WeaponConfing : ScriptableObject, IComparable<WeaponConfing>
    {
        [SerializeField]
        internal WeaponObjectsLOL.Weapon weaponPrefab;

        [SerializeField, Space]
        public TransformData weaponTransformData;

        [SerializeField]
        public int sortingOrder = 1;

        [SerializeField]
        public RuntimeAnimatorController characterAnimatorController;

        [SerializeField, Space]
        public Sprite weaponIconBase;

        [SerializeField, FormerlySerializedAs("weaponIcon")]
        public Sprite weaponIconRounded;

        protected internal abstract IWeaponController instantiateWeaponController(
            IAtomicObject owner, WeaponObjectsLOL.Weapon weapon);
        
        public int CompareTo(WeaponConfing other)
        {
            return sortingOrder.CompareTo(other.sortingOrder);
        }
    }
    
    [Serializable]
    public sealed class TransformData
    {
        public Vector3 position;
        public Vector3 eulerAngles;
        public Vector3 scale;
        public Quaternion rotation => Quaternion.Euler(this.eulerAngles);
    }
}