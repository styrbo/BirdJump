using System;
using System.Linq;
using UnityEngine;

namespace Core.Platforms
{
    public class PlatformPool : MonoBehaviour
    {
        public Action<Platform> OnPlatformCreated;
        
        [SerializeField] private Platform _platformPrefab;
        [SerializeField] private int _platformsCount;
        [SerializeField] private float _minYPos;
        [SerializeField] private float _initYPos, _distanceBetweenPlatform;

        private Platform[] _platforms;
        private int _lastPlatformIndex;

        public float DistanceBetweenPlatform => _distanceBetweenPlatform;
        public int PlatformsCount => _platformsCount;
        public float MinYPos => _minYPos;
        public float InitYPos => _initYPos;
        
        private float UppestPlatformPos => _platforms.Max(platform => platform.transform.position.y);

        private void Start()
        {
            _platforms = CreatePlatforms();
        }

        private Platform[] CreatePlatforms()
        {
            var array = new Platform[PlatformsCount];
            var pos = new Vector2(0, InitYPos);
            
            for (var i = 0; i < PlatformsCount; i++)
            {
                var platform = Instantiate(_platformPrefab, pos, Quaternion.identity);

                platform.RespawnPlatform(i);
                OnPlatformCreated?.Invoke(platform);

                array[i] = platform;
                pos += Vector2.up * DistanceBetweenPlatform;
            }

            _lastPlatformIndex = PlatformsCount - 1;
            return array;
        }

        private void MovePlatformToUp(Platform platform)
        {
            _lastPlatformIndex++;
            
            var upPos = new Vector3(0, DistanceBetweenPlatform + UppestPlatformPos , 0);;

            platform.OnDestroy?.Invoke();
            
            platform.transform.position = upPos;
            platform.RespawnPlatform(_lastPlatformIndex);
            OnPlatformCreated?.Invoke(platform);
        }

        public void TranslatePlatforms(float pos)
        {
            var position = new Vector3(0, pos);
            foreach (var platform in _platforms)
            {
                platform.transform.position += position;
                
                if(platform.transform.position.y < MinYPos)
                    MovePlatformToUp(platform);
            }
        }
    }
}