using System;
using Actions;
using Atomic.Behaviours;
using Atomic.Elements;
using Atomic.Objects;
using Components;
using DefaultNamespace;
using UnityEngine;

namespace Object
{
    public class Bullet : AtomicBehaviour
    {
        [SerializeField] private AtomicVariable<int> damage;
        public MoveComponent MoveComponent;
        public DealDamageAction DealDamageAction;

        private void Awake()
        {
            Compose();
            MoveComponent.Compose(transform);
            DealDamageAction.Compose(damage);
        }

        private void Update()
        {
            MoveComponent.OnUpdate(Time.deltaTime);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out AtomicObject target))
            {
                if (target.Is(ObjectType.Damagable))
                {
                    DealDamageAction.Invoke(target);
                }
                
                Destroy(gameObject);
            }
        }
    }
}