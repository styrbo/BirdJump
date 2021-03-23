using System;
using Core.Platforms;
using UnityEngine;

namespace Core.Character
{
    public class Character : MonoBehaviour
    {
        public Action<Platform> OnTouchToPlatform;
    }
}