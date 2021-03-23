using Core.Character;
using UnityEngine;
using Zenject;

namespace Core.Platforms
{
    class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private int _startIndexForSpawn = 4;
        [SerializeField] [Range(0,1)] private float _spawnChange;
        //TODO: будь бы ещё время, запулил бы врагов
        [SerializeField] private Enemy[] _enemiesPrefabs;
        
        [Inject] private PlatformPool _pool;

        private void Awake()
        {
            _pool.OnPlatformCreated += OnPlatformCreated;
        }

        private void OnPlatformCreated(Platforms.Platform platform)
        {
            if (platform.Level < _startIndexForSpawn || _spawnChange <= Random.value)
                return;

            var enemyIndex = Random.Range(0, _enemiesPrefabs.Length);
            var prefab = Instantiate(_enemiesPrefabs[enemyIndex]);
            prefab.AttachOnPlatform(platform);
        }
    }
}