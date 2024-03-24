using Atomic.Elements;
using Controllers;
using UnityEngine;

namespace Object.Weapon
{
    public class FireSpreadBulletAction : IAtomicAction
    {
        private IBulletPool bulletPool;
        private Transform firePoint;

        public void Compose(IBulletPool bulletPool, Transform firePoint)
        {
            this.bulletPool = bulletPool;
            this.firePoint = firePoint;

        }
        public void Invoke()
        {
            var position = firePoint.position;
            var rotation = firePoint.rotation;
            bulletPool.Spawn(position, rotation);
        }
    }
}