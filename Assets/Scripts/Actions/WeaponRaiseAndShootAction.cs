using System;
using Atomic.Elements;

namespace Actions
{
    [Serializable]
    public class WeaponRaiseAndShootAction : IAtomicAction
    {
        private IAtomicAction bulletAction;
        private IAtomicEvent shootEvent;
        public void Compose(IAtomicAction bulletAction, IAtomicEvent eAtomicEvent, IAtomicEvent shootEvent)
        {
            this.bulletAction = bulletAction;
            eAtomicEvent.Subscribe(Invoke);
            this.shootEvent = shootEvent;
        }
        public void Invoke()
        {
            bulletAction?.Invoke();
            shootEvent?.Invoke();
        }
    }
}