using System;
using Core.Platforms;
using UnityEngine;
using Zenject;

namespace Core.Characters
{
    [RequireComponent(typeof(Collider2D))]
    public class Player : Character
    {
        public Action<int> OnScoreUpdate;
        public Action OnDead;

        public bool IsDead { get; private set; }

        [Inject] private CharacterJump _jump;
        [Inject] private CharacterMovement _movement;

        private void Awake()
        {
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
                OnDead?.Invoke();
                IsDead = true;
                
                _movement.StopMove();
            }
        }
    }
}