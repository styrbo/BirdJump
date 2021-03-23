using System;
using Core.Platforms;
using UnityEngine;

namespace Core.Characters
{
    public class Character : MonoBehaviour
    {
        public Action<Platform> OnTouchToPlatform;
    }
}