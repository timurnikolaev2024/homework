using System;
using System.Collections.Generic;
using Actions;
using Atomic.Elements;
using Atomic.Objects;
using Functions;
using UnityEngine;

namespace Components
{
    [Serializable]
    public class FireComponent
    {
        public AtomicVariable<bool> enabled = new(true);
        public AtomicEvent fireEvent;

        public Transform firePoint;
        public MonoBehaviour bulletPrefab;
        public AtomicVariable<int> charges = new(10);
        
        public FireAction fireAction;
        public AndExpression fireCondition;
        public SpawnBulletAction bulletAction;
        
        public void Compose()
        {
            fireCondition = new AndExpression();
            fireCondition.Append(enabled);
            fireCondition.Append(this.charges.AsFunction(it => it.Value > 0));
            
            this.fireAction.Compose(this.bulletAction, this.charges, this.fireCondition, this.fireEvent);
            this.bulletAction.Compose(this.firePoint, this.bulletPrefab);
        }

        public void Dispose()
        {
            this.fireEvent?.Dispose();
            this.charges?.Dispose();
        }
    }
}