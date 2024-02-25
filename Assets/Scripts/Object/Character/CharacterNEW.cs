using System;
using Atomic.Behaviours;

namespace Object
{
    public class CharacterNEW : AtomicBehaviour
    {
        public Character_Core core;
        public Character_View view;

        private void Awake()
        {
            Compose();
            core.Compose();
            view.Compose(core);
        }

        private new void OnEnable()
        {
            core.OnEnable();
            view.OnEnable();
        }

        private new void OnDisable()
        {
            core.OnDisable();
            view.OnDisable();
        }

        private new void Update()
        {
            core.Update();
            view.Update();
        }
    }
}