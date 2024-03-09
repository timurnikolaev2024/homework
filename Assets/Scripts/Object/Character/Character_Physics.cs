using System;
using Atomic.Behaviours;
using DefaultNamespace.Physics;

namespace Object
{
    [Serializable]
    public class Character_Physics : IEnable, IFixedUpdate
    {
        public TriggerDispatcher triggerDispatcher;
        public void Enable()
        {
            throw new System.NotImplementedException();
        }

        public void OnFixedUpdate(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}