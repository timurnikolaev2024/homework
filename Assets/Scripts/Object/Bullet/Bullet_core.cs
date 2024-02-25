using System;
using Actions;
using Atomic.Elements;
using Atomic.Objects;
using Components;
using DefaultNamespace;
using UnityEngine;

namespace Object
{
    [Serializable]
    public class Bullet_core
    {
        [SerializeField] private Transform transform;
        [SerializeField] private AtomicVariable<int> damage;
        public MoveComponent MoveComponent;
        public DealDamageAction DealDamageAction;
        public AtomicEvent dealDamageEvent;

        public void Compose()
        {
            MoveComponent.Compose(transform);
            DealDamageAction.Compose(damage);
        }

        public void Update()
        {
            MoveComponent.OnUpdate(Time.deltaTime);
        }
        
        public void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out AtomicObject target))
            {
                if (target.Is(ObjectType.Damagable))
                {
                    DealDamageAction.Invoke(target);
                    dealDamageEvent?.Invoke();
                }
            }
        }
    }
}