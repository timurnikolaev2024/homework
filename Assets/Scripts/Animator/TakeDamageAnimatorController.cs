using Atomic.Elements;
using Components;
using UnityEngine;

namespace Animator
{
    public class TakeDamageAnimatorController
    {
        private static readonly int TakeDamage = UnityEngine.Animator.StringToHash("TakeDamage");
        private readonly UnityEngine.Animator animator;
        private readonly IAtomicEvent<int> takeDamageEvent;
        private readonly IAtomicVariable<int> hitPoints;
        public TakeDamageAnimatorController(UnityEngine.Animator animator, HealthComponent healthComponent)
        {
            this.animator = animator;
            this.takeDamageEvent = healthComponent.takeDamageEvent;
            this.hitPoints = healthComponent.hitPoints;
        }

        public void OnEnable()
        {
            takeDamageEvent.Subscribe(OnTakeDamage);
        }

        public void OnDisable()
        {
            takeDamageEvent.Unsubscribe(OnTakeDamage);
        }

        private void OnTakeDamage(int dmg)
        {
            if (hitPoints.Value > 0)
            {
                Debug.Log("timur dmg!");
                animator.SetTrigger(TakeDamage);
            }
        }
    }
}