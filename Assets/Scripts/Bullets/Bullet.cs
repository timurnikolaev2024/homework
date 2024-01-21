using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public bool IsPlayer { get; private set; }
        public int Damage { get; private set; }
        
        private new Rigidbody2D rigidbody2D;
        private SpriteRenderer spriteRenderer;
        private BulletCollisionHandler collisionHandler;

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            
            collisionHandler = this.gameObject.AddComponent<BulletCollisionHandler>();
        }
        
        public void Init(BulletSystem.Args args)
        {
            this.IsPlayer = args.isPlayer;
            this.Damage = args.damage;
            this.rigidbody2D.velocity = args.velocity;
            this.gameObject.layer = args.physicsLayer;
            this.transform.position = args.position;
            this.spriteRenderer.color = args.color;
        }

        public bool IsInBounds(LevelBounds levelBounds)
        {
            if (levelBounds == null)
            {
                return true;
            }
            
            Vector3 position = transform.position;
            return levelBounds.InBounds(position);
        }
    }
}