using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

namespace ShootEmUp
{
    public class BulletManager : IBulletManager
    {
        private readonly GameObject prefab;
        private readonly Transform container;
        private readonly LevelBounds levelBounds;
        private readonly Transform worldTransform;
        private readonly int initialCount;
        
        private readonly Queue<Bullet> m_bulletPool = new();
        private readonly HashSet<Bullet> m_activeBullets = new();
        private readonly List<Bullet> m_cache = new();
        private IBulletCreator bulletCreator;
        public BulletManager(GameObject prefab, Transform container, LevelBounds levelBounds, Transform worldTransform,
        int initialCount)
        {
            this.prefab = prefab;
            this.container = container;
            this.levelBounds = levelBounds;
            this.worldTransform = worldTransform;
            this.initialCount = initialCount;
            bulletCreator = new BulletCreator();
        }
        public void Init()
        {
            for (var i = 0; i < this.initialCount; i++)
            {
                var bullet = bulletCreator.CreateBullet(this.prefab, this.container);
                this.m_bulletPool.Enqueue(bullet);
            }
        }

        public void FixedUpdate()
        {
            this.m_cache.Clear();
            this.m_cache.AddRange(this.m_activeBullets);

            for (int i = 0, count = this.m_cache.Count; i < count; i++)
            {
                var bullet = this.m_cache[i];
                if (!this.levelBounds.InBounds(bullet.transform.position))
                {
                    this.RemoveBullet(bullet);
                }
            }
        }

        public void FlyBulletByArgs(BulletSystem.Args args)
        {
            if (this.m_bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(this.worldTransform);
            }
            else
            {
                bullet = bulletCreator.CreateBullet(this.prefab, this.worldTransform);
            }
            bullet.Init(args);

            if (this.m_activeBullets.Add(bullet))
            {
                bullet.GetComponent<BulletCollisionHandler>().OnCollisionEntered += this.OnBulletCollision;
            }
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            this.RemoveBullet(bullet);
        }
        
        private void RemoveBullet(Bullet bullet)
        {
            if (this.m_activeBullets.Remove(bullet))
            {
                bullet.GetComponent<BulletCollisionHandler>().OnCollisionEntered -= this.OnBulletCollision;
                bullet.transform.SetParent(this.container);
                this.m_bulletPool.Enqueue(bullet);
            }
        }
    }
}