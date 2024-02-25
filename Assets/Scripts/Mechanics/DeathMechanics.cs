using System;
using Atomic.Elements;
using UnityEngine;

namespace Mechanics
{
    [Serializable]
    public class DeathMechanics
    {
        private readonly IAtomicObservable<int> hp;
        private readonly IAtomicEvent deathEvent;

        public DeathMechanics(IAtomicObservable<int> hitPoints, IAtomicEvent deathEvent)
        {
            this.hp = hitPoints;
            this.deathEvent = deathEvent;
        }
        private void OnHPChanged(int hp)
        {
            if(hp <= 0)
                deathEvent?.Invoke();
        }

        public void OnEnable()
        {
            hp.Subscribe(OnHPChanged);
        }

        public void OnDisable()
        {
            hp.Unsubscribe(OnHPChanged);
        }
    }
}