using Core.Platforms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Characters
{
    public class Enemy : Characters.Character
    {
        [SerializeField] private float _minXPosForSpawn, _maxXPosForSpawn;

        private Platform _platform;

        public void AttachOnPlatform(Platform platform)
        {
            transform.position = platform.transform.position;
            transform.position += Vector3.right * Random.Range(_minXPosForSpawn, _maxXPosForSpawn);
            transform.parent = platform.transform;
            
            platform.OnDestroy += OnPlatformDestroy;
            _platform = platform;
        }

        private void OnPlatformDestroy()
        {
            _platform.OnDestroy -= OnPlatformDestroy;
            Destroy(gameObject);
        }
    }
}