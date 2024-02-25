using System;
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

        public void Compose()
        {
            moveComponent.Compose(transform);
            rotateMechanics = new RotateMechanics(transform, moveComponent.MoveDirection, moveComponent.IsMoving);
            healthComponent.Compose();
            FireComponent.Let(it =>
            {
                it.Compose();
                it.fireCondition.Append(moveComponent.IsMoving.AsNot());
            });
        }

        public void OnEnable()
        {
            healthComponent.OnEnable();
        }

        public void OnDisable()
        {
            healthComponent.OnDisable();
        }

        public void Update()
        {
            rotateMechanics.Update();
            moveComponent.OnUpdate(Time.deltaTime);
        }
    }
}