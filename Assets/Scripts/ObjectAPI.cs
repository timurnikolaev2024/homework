using UnityEngine.Analytics;

namespace DefaultNamespace
{
    public static class ObjectAPI
    {
        public const string Transform = nameof(Transform);
        public const string MoveDirection = nameof(MoveDirection);
        public const string FireAction = nameof(FireAction);
        public const string TakeDamageAction = nameof(TakeDamageAction);
        public const string HitPoints = nameof(HitPoints);
        public const string IsAlive = nameof(IsAlive);
        public const string Animator = nameof(Animator);
    }

    public static class WeaponAPI
    {
        public const string Config = nameof(Config);
        public const string CanFire = nameof(CanFire);
        public const string FireAction = nameof(FireAction);
        public const string Magazine = nameof(Magazine);
        public const string FireEvent = nameof(FireEvent);
        public const string CurrentWeapon = nameof(CurrentWeapon);
        public const string WeaponStorage = nameof(WeaponStorage);
        public const string SwitchWeaponAction = nameof(SwitchWeaponAction);
        public const string AddWeaponAmmoAction = nameof(AddWeaponAmmoAction);
    }

    public static class ItemAPI
    {
        public const string PickUp = nameof(PickUp);
    }
}