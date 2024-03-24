using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = System.Random;

namespace Object.Weapon
{
    [Serializable]
    public class WeaponMagazine
    {
        public event Action OnStateChanged;

        [SerializeField, Min(0), MaxValue(nameof(max))]
        private int current;
        
        [SerializeField, Min(0)] private int max;

        public int Current => current;
        public int Max
        {
            get => max;
            set => max = Math.Max(0, value);
        }

        public bool IsFull()
        {
            return current >= max;
        }

        public bool IsNotFull()
        {
            return current < max;
        }

        public bool IsEmpty()
        {
            return current == 0;
        }

        public int GetFreeSlots()
        {
            return Math.Max(0, max - current);
        }
        
        public bool IsNotEmpty()
        {
            return this.current > 0;
        }

        public void SpendCharge()
        {
            if (current <= 0)
            {
                throw new Exception("Cant spend chagrges");
            }

            current--;
            OnStateChanged?.Invoke();
        }

        public void AddCharges(int charges)
        {
            current = Mathf.Min(current + charges, max);
            OnStateChanged?.Invoke();
        }

        public void SetFull()
        {
            current = max;
            OnStateChanged?.Invoke();
        }

        public float GetProgress()
        {
            return (float)current / max;
        }
        
        
    }
}