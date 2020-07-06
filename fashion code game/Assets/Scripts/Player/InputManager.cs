using UnityEngine;

namespace Player
{
    public class InputManager : MonoBehaviour
    {
        private IsometricPlayerMovementController _movementController;
        private bool _noKeyPressed;

        private void Start()
        {
            _movementController = gameObject.GetComponent<IsometricPlayerMovementController>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _noKeyPressed = false;
                _movementController.Move(1, 1);
            }

            if (Input.GetKey(KeyCode.A))
            {
                _noKeyPressed = false;
                _movementController.Move(-1, 1);
            }

            if (Input.GetKey(KeyCode.S))
            {
                _noKeyPressed = false;
                _movementController.Move(-1, -1);
            }

            if (Input.GetKey(KeyCode.D))
            {
                _noKeyPressed = false;
                _movementController.Move(1, -1);
            }

            if (Input.anyKey && !_noKeyPressed) return;
            _noKeyPressed = true;
            _movementController.Move(0, 0);
        }
    }
}
