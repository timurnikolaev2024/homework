using Atomic.Elements;
using UnityEngine;

namespace Controllers
{
    public class DeathAnimatorController
    {
        private static readonly int Death = Animator.StringToHash("Death");
        
        private readonly Animator animator;
        private readonly IAtomicObservable deathEvent;

        public DeathAnimatorController(Animator animator, IAtomicObservable deathEvent)
        {
            this.animator = animator;
            this.deathEvent = deathEvent;
        }
        private void OnDeath()
        {
            this.animator.SetTrigger(Death);
        }

        public void OnEnable()
        {
            this.deathEvent.Subscribe(this.OnDeath);
        }

        public void OnDisable()
        {
            this.deathEvent.Unsubscribe(this.OnDeath);
        }
    }
}