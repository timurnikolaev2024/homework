using Object;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

namespace Controllers
{
    public interface IBulletPool
    {
        void Spawn(Vector3 pos, Quaternion rotation);
    }
}