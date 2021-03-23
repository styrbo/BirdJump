using Core.Characters;
using UnityEngine;
using Zenject;

namespace Core.Platforms
{
    class PlatformTranslator : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        [Inject] private Player _player;
        [Inject] private PlatformPool _platformPool;

        private Vector3 _playerStartPos; 

        private void Awake()
        {
            _platformPool = GetComponent<PlatformPool>();
        }

        private void Start()
        {
            _playerStartPos = _player.transform.position;
        }

        private void FixedUpdate()
        {
            var deltaPos = _playerStartPos - _player.transform.position;
            
            _platformPool.TranslatePlatforms(deltaPos.y * Time.fixedDeltaTime);
        }
    }
}