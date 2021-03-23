using Core.Character;
using UnityEngine;
using Zenject;

namespace UI
{
    public class PlayerJumping : MonoBehaviour
    {
        [Inject] private Player _player;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                _player.Jump();
        }
    }
}