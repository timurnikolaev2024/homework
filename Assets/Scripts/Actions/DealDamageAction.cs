using System;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using DefaultNamespace;
using UnityEngine;

namespace Actions
{
    [Serializable]
    public class DealDamageAction : IAtomicAction<IAtomicObject>
    {
        private IAtomicVariable<int> _damage;
        private IAtomicAction<int> _damageAction;

        public void Compose(IAtomicVariable<int> damage)
        {
            _damage = damage;
        }

        public void Invoke(IAtomicObject args)
        {
            var damageAction = args.GetAction<int>(ObjectAPI.TakeDamageAction);
            damageAction?.Invoke(_damage.Value);
        }
    }
}