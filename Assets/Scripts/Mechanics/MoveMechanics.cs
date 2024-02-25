using Atomic.Elements;
using UnityEngine;

namespace Mechanics
{
    public class MoveMechanics
    {private readonly IAtomicValue<bool> moveEnabled;
        
        private readonly IAtomicValue<Vector3> moveDirection;
        private readonly IAtomicValue<float> moveSpeed;
        private readonly Transform transform;

        private float _currentVel;

        public MoveMechanics(
            IAtomicValue<bool> moveEnabled,
            IAtomicValue<Vector3> moveDirection,
            IAtomicValue<float> moveSpeed,
            Transform transform
        )
        {
            this.moveEnabled = moveEnabled;
            this.moveDirection = moveDirection;
            this.moveSpeed = moveSpeed;
            this.transform = transform;
        }

        public void FixedUpdate(float time)
        {
            if (this.moveEnabled.Value)
            {
                // var targetAngle = Mathf.Atan2(moveDirection.Value.x, moveDirection.Value.z) * Mathf.Rad2Deg;
                // var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVel, 0.05f);
                // transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
                
                Vector3 moveOffset = this.moveDirection.Value.normalized * (this.moveSpeed.Value * time);
                this.transform.position += moveOffset;
            }
        }
    }
}