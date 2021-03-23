using System;
using UnityEngine;

namespace Core.Platforms
{
    public class Platform : MonoBehaviour
    {
        public Action OnDestroy;
        public int Level { get; private set; }

        private void OnCollisionEnter2D(Collision2D other)
        {
            //https://forum.unity.com/threads/collision-with-platform-effector-2d.420304/
            if(other.enabled == false)
                return;
            
            if (other.transform.TryGetComponent(out Character.Character character))
            {
                character.OnTouchToPlatform?.Invoke(this);
            }
        }

        public void RespawnPlatform(int level)
        {
            Level = level;
        }
    }
}