using UnityEngine;

namespace Player
{
    public class IsometricPlayerMovementController : MonoBehaviour
    {
        public float movementSpeed = 1f;
        
        private MovementState _movementState;
        private Rigidbody2D _rigidBody2D;

        void Start()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            var currentPos = _rigidBody2D.position;
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");
            var inputVector = new Vector2(horizontalInput, verticalInput);
            inputVector = Vector2.ClampMagnitude(inputVector, 1);
            var movement = inputVector * movementSpeed;
            var newPos = currentPos + movement * Time.fixedDeltaTime;
            _rigidBody2D.MovePosition(newPos);
        }
    }
}
