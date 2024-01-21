using System;
using UnityEngine;

namespace ShootEmUp
{
    public class BulletCollisionHandler : MonoBehaviour
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Bullet bullet = GetComponent<Bullet>();
            if (bullet != null)
            {
                OnCollisionEntered?.Invoke(bullet, collision);
            }
        }
    }
}