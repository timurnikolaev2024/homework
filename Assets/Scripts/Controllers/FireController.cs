using Atomic.Elements;
using Object;
using UnityEngine;

namespace Controllers
{
    public class FireController : MonoBehaviour
    {
        [SerializeField] private Character character;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.character.core.FireComponent.fireAction?.Invoke();
            }
        }
    }
}