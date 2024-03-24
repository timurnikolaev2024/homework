using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Object.Weapon
{
    [Serializable]
    public class WeaponsStorage
    {
        public event Action<WeaponObjectsLOL.Weapon> OnWeaponAdded;
        public event Action<WeaponObjectsLOL.Weapon> OnWeaponRemoved;
        
        [ShowInInspector, ReadOnly]
        private readonly SortedList<WeaponConfing, WeaponObjectsLOL.Weapon> weapons = new();

        public IEnumerable<WeaponObjectsLOL.Weapon> GetSortedWeapons()
        {
            return this.weapons.Values;
        }

        public bool AddWeapon(WeaponObjectsLOL.Weapon weapon)
        {
            if (this.weapons.TryAdd(weapon.Config, weapon))
            {
                this.OnWeaponAdded?.Invoke(weapon);
                return true;
            }
            
            return false;
        }

        public bool RemoveWeapon(WeaponConfing config, out WeaponObjectsLOL.Weapon weapon)
        {
            if (this.weapons.Remove(config, out weapon))
            {
                this.OnWeaponRemoved?.Invoke(weapon);
                return true;
            }
            
            return false;
        }

        public bool HasWeapon(WeaponConfing config)
        {
            return this.weapons.ContainsKey(config);
        }

        public WeaponObjectsLOL.Weapon GetWeapon(WeaponConfing config)
        {
            return this.weapons[config];
        }

        public bool TryGetWeapon(WeaponConfing config, out WeaponObjectsLOL.Weapon weapon)
        {
            return this.weapons.TryGetValue(config, out weapon);
        }
    }
}