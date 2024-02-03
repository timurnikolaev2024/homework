using Atomic.Elements;
using UnityEngine;

namespace Mechanics
{
    public class RotateMechanics
    {
        private readonly IAtomicValue<Vector3> moveDirection;
        private readonly Transform transform;
        private const float _smoothTime = 0.05f;
        private float _currentVel;
        private readonly IAtomicValue<bool> moveEnabled;

        public RotateMechanics(Transform transform, IAtomicValue<Vector3> moveDirection, IAtomicValue<bool> moveEnabled)
        {
            this.transform = transform;
            this.moveDirection = moveDirection;
            this.moveEnabled = moveEnabled;
        }

        public void Update()
        {
            if (moveEnabled.Value)
            {
                var targetAngle = Mathf.Atan2(moveDirection.Value.x, moveDirection.Value.z) * Mathf.Rad2Deg;
                var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,
                    ref _currentVel, _smoothTime);
                transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
            }
        }
    }
}