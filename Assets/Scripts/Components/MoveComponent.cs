using System;
using Atomic.Behaviours;
using Atomic.Elements;
using Atomic.Objects;
using Mechanics;
using UnityEngine;

namespace Components
{
    [Serializable]
    public class MoveComponent : IDisposable
    {
        [SerializeField] private AtomicFunction<bool> isMoving = new();
        [SerializeField] private AtomicVariable<Vector3> direction = new();
        [SerializeField] private AtomicVariable<float> speed = new();
        
        public IAtomicVariable<Vector3> MoveDirection => this.direction;
        public IAtomicValue<bool> IsMoving => this.isMoving;
        private MoveMechanics moveMechanics;
        public void Compose(Transform transform)
        {
            isMoving.Compose(() => direction.Value.magnitude > 0);
            moveMechanics = new MoveMechanics(
                this.isMoving, this.direction, this.speed, transform
            );

        }

        public void Dispose()
        {
            // TODO release managed resources here
        }

        public void OnUpdate(float time)
        {
            moveMechanics.FixedUpdate(time);
        }
    }
}