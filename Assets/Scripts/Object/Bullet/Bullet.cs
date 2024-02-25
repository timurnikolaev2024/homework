using System;
using Actions;
using Atomic.Behaviours;
using Atomic.Elements;
using Atomic.Objects;
using Components;
using DefaultNamespace;
using UnityEngine;

namespace Object
{
    public class Bullet : AtomicBehaviour
    {
        [Section] public Bullet_core core;
        [Section] public Bullet_view view;//empty

        private void Awake()
        {
            Compose();
            core.Compose();
        }

        private void Update()
        {
            core.Update();
        }

        private void OnCollisionEnter(Collision other)
        {
            core.OnCollisionEnter(other);
        }
    }
}