using System;
using System.Collections;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Core.Characters
{
    public class CharacterMovement : MonoBehaviour
    {
        public enum Side
        {
            Left = -1,
            Right = 1
        }

        public Action<Side> OnChangeSide;

        [SerializeField] private float _minPosX, _maxPosX;
        [SerializeField] private float _speed;

        [Inject] private Rigidbody2D _rb2d;
        
        private Side _currentSide;
        private Coroutine _coroutine;

        public Side CurrentSide
        {
            get => _currentSide;
            set
            {
                OnChangeSide?.Invoke(value);
                _currentSide = value;
            }
        }

        private void Awake()
        {
            if(_rb2d == null)
                _rb2d = GetComponent<Rigidbody2D>();
        }

        public void StartMove()
        {
            var randomSide = (Side) Mathf.Pow(-1, Random.Range(1, 3));
            StartMove(randomSide);
        }

        public void StartMove(Side side)
        {
            CurrentSide = side;
            _coroutine = StartCoroutine(Movement());
        }

        public void StopMove()
        {
            StopCoroutine(_coroutine);
        }

        private IEnumerator Movement()
        {
            while (true)
            {
                if (CurrentSide == Side.Left && transform.position.x < _minPosX ||
                    CurrentSide == Side.Right && transform.position.x > _maxPosX)
                {
                    CurrentSide = (Side)((int) CurrentSide * -1);
                }
                
                transform.position += Time.deltaTime * (int)CurrentSide * _speed * Vector3.right; 

                yield return new WaitForFixedUpdate();
            }
        }
    }
}