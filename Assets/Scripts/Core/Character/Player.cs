using System;
using Core.Platforms;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Core.Character
{
    [RequireComponent(typeof(Collider2D))]
    public class Player : Character
    {
        public Action<int> OnScoreUpdate;
        
        [Inject] private CharacterMovement _movement;
        [Inject] private CharacterJump _jump;
        [Inject] private PlatformPool _pool;

        private void Awake()
        {
            _movement.StartMove();
            
            base.OnTouchToPlatform += OnTouchToPlatform;
        }

        private new void OnTouchToPlatform(Platform platform)
        {
            OnScoreUpdate?.Invoke(platform.Level);
        }

        public void Jump()
        {
            if(_jump.TryJump() == false)
                return;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.TryGetComponent(out Enemy enemy))
            {
                print("restart level");
                SceneManager.LoadScene(0);
            }
        }
    }
}