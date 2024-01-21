using UnityEngine;

namespace ShootEmUp
{
    public interface IBulletCreator
    {
        Bullet CreateBullet(GameObject prefab, Transform container);
    }
}