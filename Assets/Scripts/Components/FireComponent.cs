using System;
using System.Collections.Generic;
using Actions;
using Atomic.Elements;
using Atomic.Objects;
using Controllers;
using DefaultNamespace;
using Functions;
using UnityEngine;

namespace Components
{
    [Serializable]
    public class FireComponent
    {
        [SerializeField] private TestAnimationEvent _test;
        [SerializeField] private BulletPool _bulletPool;
        public AtomicVariable<bool> enabled = new(true);
        public AtomicEvent firstPhaseFireEvent;
        public AtomicEvent secondPhaseFireEvent;

        public Transform firePoint;
        public AtomicVariable<int> charges = new(10);
        
        public FireAction fireAction;
        public AndExpression fireCondition;
        public SpawnBulletAction bulletAction;
        public WeaponRaiseAndShootAction weaponRaiseAndShootAction;
        public void Compose()
        {
            fireCondition = new AndExpression();
            fireCondition.Append(enabled);
            fireCondition.Append(this.charges.AsFunction(it => it.Value > 0));
            
            this.fireAction.Compose(this.bulletAction, this.charges, this.fireCondition, this.firstPhaseFireEvent);
            this.bulletAction.Compose(this.firePoint, _bulletPool);
            weaponRaiseAndShootAction.Compose(this.bulletAction, _test.shootEvent2, secondPhaseFireEvent);
        }

        public void Dispose()
        {
            this.firstPhaseFireEvent?.Dispose();
            this.charges?.Dispose();
        }
    }
}