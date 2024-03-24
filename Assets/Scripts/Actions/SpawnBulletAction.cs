using System;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using Controllers;
using Object;
using UnityEngine;

namespace Actions
{
    [Serializable]
    public class SpawnBulletAction : IAtomicAction
    {
        private Transform firePoint;
        private BulletPool bulletPool;

        public void Compose(Transform firePoint, BulletPool bulletPool)
        {
            this.firePoint = firePoint;
            this.bulletPool = bulletPool;
        }

        public void Invoke()
        {
            var bullet = bulletPool.GetObjectFromPool();

            bullet.gameObject.transform.position = firePoint.position;
            bullet.gameObject.transform.rotation = firePoint.rotation;

            IAtomicVariable<Vector3> bulletDirection = bullet.GetComponent<Bullet>().core.MoveComponent.MoveDirection;
            if (bulletDirection != null)
            {
                bulletDirection.Value = this.firePoint.forward;
            }
        }
    }
}