using Atomic.Behaviours;
using Atomic.Elements;
using UnityEngine;

namespace Controllers
{
    public class MoveAnimatorController : IUpdate
    {
        private static readonly int IsMoving = UnityEngine.Animator.StringToHash("IsMoving");
        private readonly UnityEngine.Animator animator;
        private readonly IAtomicValue<bool> isMoving;

        public MoveAnimatorController(UnityEngine.Animator animator, IAtomicValue<bool> isMoving)
        {
            this.animator = animator;
            this.isMoving = isMoving;
        }

        public void OnUpdate(float deltaTime)
        {
            this.animator.SetBool(IsMoving, this.isMoving.Value);
        }
    }
}