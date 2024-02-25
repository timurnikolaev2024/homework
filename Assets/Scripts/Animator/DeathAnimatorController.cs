using Atomic.Elements;
using UnityEngine;

namespace Controllers
{
    public class DeathAnimatorController
    {
        private static readonly int Death = UnityEngine.Animator.StringToHash("Death");
        
        private readonly UnityEngine.Animator animator;
        private readonly IAtomicObservable deathEvent;

        public DeathAnimatorController(UnityEngine.Animator animator, IAtomicObservable deathEvent)
        {
            this.animator = animator;
            this.deathEvent = deathEvent;
        }
        private void OnDeath()
        {
            Debug.Log("timur death");
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