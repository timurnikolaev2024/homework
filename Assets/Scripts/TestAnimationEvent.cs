using Atomic.Elements;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestAnimationEvent : MonoBehaviour
    {           
        public AtomicEvent shootEvent2;
        public void ReceiveEvent(string lol)
        {
            shootEvent2?.Invoke();
        }
    }
}