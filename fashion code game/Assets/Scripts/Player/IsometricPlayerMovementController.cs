using UnityEngine;

namespace Player
{
    public class IsometricPlayerMovementController : MonoBehaviour
    {
        private const float MovementSpeed = 1f;
        
        private MovementState _movementState;
        private Rigidbody2D _rigidBody2D;
        private PlayerAnimationHandler _playerAnimationHandler;

        private void Start()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _playerAnimationHandler = GetComponent<PlayerAnimationHandler>();    
        }

        public void Move(float horizontalModifier, float verticalModifier)
        {
            var currentPos = _rigidBody2D.position;
            var inputVector = new Vector2(horizontalModifier, verticalModifier);
            inputVector = Vector2.ClampMagnitude(inputVector, 1);
            var movement = inputVector * MovementSpeed;
            _playerAnimationHandler.SetPlayerAnimation(horizontalModifier, verticalModifier);
            var newPos = currentPos + movement * Time.fixedDeltaTime;
            _rigidBody2D.MovePosition(newPos);
        }
    }
}
