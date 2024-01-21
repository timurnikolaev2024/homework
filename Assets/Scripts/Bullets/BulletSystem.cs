using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField] private int initialCount = 50;
        [SerializeField] private Transform container;
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform worldTransform;
        [SerializeField] private LevelBounds levelBounds;
        
        private IBulletManager bulletManager;
        
        private void Awake()
        {
            bulletManager = new BulletManager(prefab, container, levelBounds, worldTransform, initialCount);
            bulletManager.Init();
        }
        
        private void FixedUpdate()
        {
            bulletManager.FixedUpdate();
        }

        public void FlyBulletByArgs(Args args)
        {
            bulletManager.FlyBulletByArgs(args);
        }
        
        public struct Args
        {
            public Vector2 position;
            public Vector2 velocity;
            public Color color;
            public int physicsLayer;
            public int damage;
            public bool isPlayer;
        }
    }
}