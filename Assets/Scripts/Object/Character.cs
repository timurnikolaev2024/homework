using System;
using Atomic.Behaviours;
using Atomic.Elements;
using Atomic.Objects;
using Components;
using Controllers;
using Mechanics;
using UnityEngine;

namespace Object
{
    public class Character : AtomicBehaviour
    {
        public AtomicVariable<bool> isAlive = new(true);

        public AtomicValue<float> moveSpeed;
        public AtomicVariable<Vector3> vectorMovementDirection;

        [SerializeField] private new Collider collider;
        [SerializeField] private Animator _animator;

        [Section]
        public MoveComponent moveComponent;
        private MoveAnimatorController movingAnimatorController;
        private DeathAnimatorController deathAnimatorController;
        private RotateMechanics rotateMechanics;
        
        [Section]
        public HealthComponent healthComponent;
        
        [Section]
        public FireComponent FireComponent;

        private void Awake()
        {
            Compose();
            movingAnimatorController = new MoveAnimatorController(_animator, moveComponent.IsMoving);
            deathAnimatorController = new DeathAnimatorController(_animator, healthComponent.deathEvent);
            moveComponent.Compose(transform);
            rotateMechanics = new RotateMechanics(transform, moveComponent.MoveDirection, moveComponent.IsMoving);
            healthComponent.Compose();
            FireComponent.Compose();
        }

        private void OnEnable()
        {
            deathAnimatorController.OnEnable();
            healthComponent.OnEnable();
        }

        private void OnDisable()
        {
            deathAnimatorController.OnDisable();
            healthComponent.OnDisable();
        }

        private void Update()
        {
            rotateMechanics.Update();
            moveComponent.OnUpdate(Time.deltaTime);
            movingAnimatorController.OnUpdate(Time.deltaTime);
        }
    }
}