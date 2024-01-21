using UnityEngine;

namespace ShootEmUp
{
    public class BulletCreator : IBulletCreator
    {
        public Bullet CreateBullet(GameObject prefab, Transform container)
        {
            var bulletObj = Object.Instantiate(prefab, container);
            return bulletObj.GetComponent<Bullet>();
        }
    }
}