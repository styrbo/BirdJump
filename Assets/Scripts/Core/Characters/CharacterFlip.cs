using UnityEngine;
using Zenject;

namespace Core.Characters
{
    public class CharacterFlip : MonoBehaviour
    {
        [Inject] private CharacterMovement _movement;

        private void Awake()
        {
            _movement.OnChangeSide += OnChangeMovementSide;
        }

        private void OnDestroy()
        {
            _movement.OnChangeSide -= OnChangeMovementSide;
        }

        private void OnChangeMovementSide(CharacterMovement.Side side)
        {
            var yRot = side == CharacterMovement.Side.Right ? 0 : 180;
            
            transform.rotation = Quaternion.Euler(0, yRot, 0);
        }
    }
}