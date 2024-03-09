using System;
using UnityEngine;

namespace DefaultNamespace.Physics
{
    [DisallowMultipleComponent]
    public sealed class TriggerDispatcher : MonoBehaviour
    {
        public event Action<Collider> OnEnter;
        public event Action<Collider> OnExit;
        
        private void OnTriggerEnter(Collider other)
        {
            this.OnEnter?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            this.OnExit?.Invoke(other);
        }
    }
}