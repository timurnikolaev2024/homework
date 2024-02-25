using System;
using Controllers;
using Mechanics;
using UnityEngine;

namespace Object
{
    [Serializable]
    public class Character_View
    {
        [SerializeField] private UnityEngine.Animator _animator;
        [SerializeField] private ParticleSystem _fireParticle;
        private MoveAnimatorController movingAnimatorController;
        private DeathAnimatorController deathAnimatorController;
        private ShootAnimatorController shootAnimatorController;
        
        public void Compose(Character_Core core)
        {
            movingAnimatorController = new MoveAnimatorController(_animator, core.moveComponent.IsMoving);
            deathAnimatorController = new DeathAnimatorController(_animator, core.healthComponent.deathEvent);
            shootAnimatorController = new ShootAnimatorController(_animator, core.FireComponent.fireEvent, _fireParticle);
        }

        public void OnEnable()
        {
            deathAnimatorController.OnEnable();
            shootAnimatorController.OnEnable();
        }

        public void OnDisable()
        {
            deathAnimatorController.OnDisable();
            shootAnimatorController.OnDisable();
        }

        public void Update()
        {
            movingAnimatorController.OnUpdate(Time.deltaTime);
        }
    }
}