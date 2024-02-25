using System;
using Atomic.Behaviours;
using Atomic.Elements;
using Atomic.Objects;
using Components;
using Controllers;
using Mechanics;
using UnityEngine;

namespace Object
{
    [Serializable]
    public class Character : AtomicBehaviour
    {
        [Section] public Character_Core core;
        [Section] public Character_View view;

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