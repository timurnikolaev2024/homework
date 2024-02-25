using Atomic.Elements;
using UnityEngine;

namespace Animator
{
    public class ShootParticleController
    {
        private ParticleSystem particleSystem;
        private IAtomicEvent shootEvent;
        public ShootParticleController(ParticleSystem particleSystem, IAtomicEvent shootEvent)
        {
            this.particleSystem = particleSystem;
            this.shootEvent = shootEvent;
        }

        public void OnEnable()
        {
            shootEvent.Subscribe(ShowParticle);
        }

        public void OnDisable()
        {
            shootEvent.Unsubscribe(ShowParticle);
        }

        private void ShowParticle()
        {
            particleSystem.Play();
        }
    }
}