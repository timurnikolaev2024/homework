using Object;
using UnityEngine;

namespace Controllers
{
    public class CharacterMoveController : MonoBehaviour
    {
        [SerializeField] private Character character;
        
        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            this.character.core.moveComponent.MoveDirection.Value = new Vector3(horizontalInput, 0f, verticalInput);
        }
    }
}