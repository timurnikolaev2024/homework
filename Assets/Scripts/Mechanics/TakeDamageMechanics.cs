using System;
using Atomic.Elements;
using UnityEngine;

namespace Mechanics
{
    [Serializable]
    public class TakeDamageMechanics
    {
        private readonly IAtomicEvent<int> _takeDamageEvent;
        private readonly IAtomicVariable<int> _hp;
        public TakeDamageMechanics(IAtomicEvent<int> takeDamageEvent, IAtomicVariable<int> hp)
        {
            _takeDamageEvent = takeDamageEvent;
            _hp = hp;
        }

        public void OnEnable()
        {
            this._takeDamageEvent.Subscribe(OnTakeDamage);
        }

        public void OnDisable()
        {
            this._takeDamageEvent.Unsubscribe(OnTakeDamage);
        }

        private void OnTakeDamage(int damage)
        {
            if (_hp.Value > 0)
            {
                Debug.Log("timur take damage");
                _hp.Value = Math.Max(0, _hp.Value - damage);
            }
        }
    }
}