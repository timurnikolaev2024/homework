using System;
using Atomic.Behaviours;
using Atomic.Objects;
using Components;

namespace Object
{
    public class Enemy : AtomicBehaviour
    {
        [Section]
        public HealthComponent healthComponent;

        private void Awake()
        {
            Compose();
            healthComponent.Compose();
        }

        private void OnEnable()
        {
            healthComponent.OnEnable();
        }

        private void OnDisable()
        {
            healthComponent.OnDisable();
        }
    }
}