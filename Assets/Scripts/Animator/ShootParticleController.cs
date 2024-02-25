using Atomic.Elements;
using UnityEngine;

namespace Animator
{
    public class ShootParticleController
    {
        private ParticleSystem particleSystem;
        public ShootParticleController(ParticleSystem particleSystem, IAtomicEvent atomicEvent)
        {
            this.particleSystem = particleSystem;
            atomicEvent.Subscribe(ShowParticle);
        }

        private void ShowParticle()
        {
            particleSystem.Play();
        }
    }
}