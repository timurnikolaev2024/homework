using System;
using System.Collections.Generic;
using Actions;
using Atomic.Elements;
using Object;
using UnityEngine;

namespace Controllers
{
    public class BulletPool : MonoBehaviour//очень просто пул, понимаю что надо сделать на очередях по хорошему
    {
        [SerializeField] private Transform parent;
        public GameObject prefab;
        public int poolSize = 10;

        private List<GameObject> objectPool = new List<GameObject>();

        private void Start()
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(prefab, parent);
                obj.SetActive(false);
                objectPool.Add(obj);
            }
        }

        public GameObject GetObjectFromPool()
        {
            foreach (GameObject obj in objectPool)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    obj.GetComponent<Bullet>().core.dealDamageEvent.Subscribe(() => Test(obj));//грязь 
                    return obj;
                }
            }

            GameObject newObj = Instantiate(prefab, parent);
            objectPool.Add(newObj);
            return newObj;
        }

        private void Test(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }
    }
}