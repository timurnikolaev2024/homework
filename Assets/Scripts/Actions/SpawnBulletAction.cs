using System;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using Object;
using UnityEngine;

namespace Actions
{
    [Serializable]
    public class SpawnBulletAction : IAtomicAction
    {
        private Transform firePoint;
        private MonoBehaviour bulletPrefab;

        public void Compose(Transform firePoint, MonoBehaviour bulletPrefab)
        {
            this.firePoint = firePoint;
            this.bulletPrefab = bulletPrefab;
        }

        public void Invoke()
        {
            MonoBehaviour bullet = GameObject.Instantiate(
                this.bulletPrefab,
                this.firePoint.position,
                this.firePoint.rotation,
                null
            );

            IAtomicVariable<Vector3> bulletDirection = bullet.GetComponent<Bullet>().MoveComponent.MoveDirection;
            if (bulletDirection != null)
            {
                bulletDirection.Value = this.firePoint.forward;
            }
        }
    }
}