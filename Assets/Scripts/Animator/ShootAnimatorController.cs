using Atomic.Elements;
using UnityEngine;

namespace Mechanics
{
    public class ShootAnimatorController
    {
        private static readonly int Shoot = UnityEngine.Animator.StringToHash("Shoot");
        
        private readonly UnityEngine.Animator animator;
        private readonly IAtomicObservable shootEvent;
        private readonly ParticleSystem particle;

        public ShootAnimatorController(UnityEngine.Animator animator, IAtomicObservable shootEvent, ParticleSystem particle)
        {
            this.animator = animator;
            this.shootEvent = shootEvent;
            this.particle = particle;
        }

        public void OnEnable()
        {
            shootEvent.Subscribe(OnShoot);
        }

        public void OnDisable()
        {
            shootEvent.Unsubscribe(OnShoot);
        }

        private void OnShoot()
        {
            animator.SetTrigger(Shoot);
        }
    }
}