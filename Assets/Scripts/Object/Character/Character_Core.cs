using System;
using Atomic.Behaviours;
using Atomic.Elements;
using Atomic.Objects;
using Components;
using DefaultNamespace;
using Mechanics;
using UnityEngine;

namespace Object
{
    [Serializable]
    public class Character_Core
    {
        [SerializeField] private new Collider collider;
        [SerializeField] private Transform transform;

        [Section] public MoveComponent moveComponent;
        private RotateMechanics rotateMechanics;
        
        [Section] public HealthComponent healthComponent;
        
        [Section] public FireComponent FireComponent;

        [Section] public PickUpComponent PickUpComponent;

        [Section] public WeaponComponent weaponComponent;

        public void Compose(Character_Physics physics, AtomicBehaviour owner)
        {
            moveComponent.Compose(transform);
            rotateMechanics = new RotateMechanics(transform, moveComponent.MoveDirection, moveComponent.IsMoving);
            healthComponent.Compose();
            FireComponent.Let(it =>
            {
                it.Compose();
                it.fireCondition.Append(moveComponent.IsMoving.AsNot());
            });
            weaponComponent.Compose(owner);
            PickUpComponent.Compose(weaponComponent, physics.triggerDispatcher);
        }

        public void OnEnable()
        {
            healthComponent.OnEnable();
            PickUpComponent.Enable();
        }

        public void OnDisable()
        {
            healthComponent.OnDisable();
            PickUpComponent.Disable();
        }

        public void Update()
        {
            rotateMechanics.Update();
            moveComponent.OnUpdate(Time.deltaTime);
        }
    }
}