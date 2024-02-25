using System;
using Animator;
using Controllers;
using DefaultNamespace;
using Mechanics;
using UnityEngine;

namespace Object
{
    [Serializable]
    public class Character_View
    {
        [SerializeField] private UnityEngine.Animator _animator;
        [SerializeField] private ParticleSystem _fireParticle;
        [SerializeField] private TestAnimationEvent _test;
        private MoveAnimatorController movingAnimatorController;
        private DeathAnimatorController deathAnimatorController;
        private ShootAnimatorController shootAnimatorController;
        private ShootParticleController shootParticleController;
        private TakeDamageAnimatorController takeDamageAnimatorController;
        
        public void Compose(Character_Core core)
        {
            movingAnimatorController = new MoveAnimatorController(_animator, core.moveComponent.IsMoving);
            deathAnimatorController = new DeathAnimatorController(_animator, core.healthComponent.deathEvent);
            shootAnimatorController = new ShootAnimatorController(_animator, core.FireComponent.firstPhaseFireEvent, _fireParticle);
            shootParticleController = new ShootParticleController(_fireParticle, core.FireComponent.secondPhaseFireEvent);
            takeDamageAnimatorController =
                new TakeDamageAnimatorController(_animator, core.healthComponent);
        }

        public void OnEnable()
        {
            deathAnimatorController.OnEnable();
            shootAnimatorController.OnEnable();
            shootParticleController.OnEnable();
            takeDamageAnimatorController.OnEnable();
        }

        public void OnDisable()
        {
            deathAnimatorController.OnDisable();
            shootAnimatorController.OnDisable();
            shootParticleController.OnDisable();
            takeDamageAnimatorController.OnDisable();
        }

        public void Update()
        {
            movingAnimatorController.OnUpdate(Time.deltaTime);
        }
    }
}