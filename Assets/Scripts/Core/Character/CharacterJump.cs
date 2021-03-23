using UnityEngine;
using Zenject;

namespace Core.Character
{
    public class CharacterJump : MonoBehaviour
    {
        [SerializeField] private int _jumpCount = 2;
        [SerializeField] private float _jumpPower;

        private int _remainingJumpCount;
        
        [Inject] private Character _character;
        [Inject] private Rigidbody2D _rb2d;

        private bool CanJump => _remainingJumpCount > 0;

        private void Awake()
        {
            _character.OnTouchToPlatform += (platform) => OnTouchToGround(); 
        }

        private void Start()
        {
            RefillJumpCount();
        }
        
        private void OnTouchToGround()
        {
            RefillJumpCount();
        }

        private void RefillJumpCount()
        {
            _remainingJumpCount = _jumpCount;
        }

        public bool TryJump()
        {
            if (!CanJump)
                return false;

            _rb2d.velocity = new Vector2(_rb2d.velocity.x, _jumpPower);
            _remainingJumpCount--;
            
            return true;
        }
    }
}