using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atomic.Elements;
using Object;
using UnityEngine;

namespace DefaultNamespace.Observers
{
    public class CharacterDisablingObserver : MonoBehaviour
    {
        [SerializeField] private List<Character> characters = new();
        public float delay = 2;

        private void Awake()
        {
            foreach (var character in characters)
            {
                character.core.healthComponent.deathEvent.Subscribe(() => OnCharacterDeathEvent(character));
            }
        }

        private async void OnCharacterDeathEvent(Character character)
        {
            await DisableCharacterAfrerDelay(character, delay);
        }

        private async Task DisableCharacterAfrerDelay(Character character, float f)
        {
            await Task.Delay((int)(f * 1000));
            
            if(character != null)
                character.gameObject.SetActive(false);
        }
    }
}