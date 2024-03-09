using Atomic.Elements;
using Atomic.Objects;
using Object.Weapon;

namespace DefaultNamespace.Items
{
    [Is(ObjectType.Pickable, ObjectType.Weapon)]
    public interface IWeaponItem : IAtomicObject
    {
        [Get(WeaponAPI.Config)] WeaponConfing Config { get; }
        
        [Get(ItemAPI.PickUp)] IAtomicAction PickUpAction { get; }
    }
}