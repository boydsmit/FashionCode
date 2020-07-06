using UnityEngine;

namespace Player
{
    public class PlayerAnimationHandler : MonoBehaviour
    {
        private Animator _animator;
        private void Start()
        {
            _animator = gameObject.GetComponent<Animator>();
        }


        public void SetPlayerAnimation(float horizontalInput, float verticalInput)
        {
            var movementState = GetDirection(horizontalInput, verticalInput);
            switch (movementState.DisplayValue)
            { 
                case "Idle":
                    _animator.SetBool("IsMoving", false);
                    break;
                
                case "Up":
                    _animator.SetBool("IsMoving", true);
                    _animator.SetInteger("MovingDirection", 1);
                    break;
                
                case "Down":
                    _animator.SetBool("IsMoving", true);
                    _animator.SetInteger("MovingDirection", 3);
                    break;
                
                case "Left":
                    _animator.SetBool("IsMoving", true);
                    _animator.SetInteger("MovingDirection", 2);
                    break;
                
                case "Right":
                    _animator.SetBool("IsMoving", true);
                    _animator.SetInteger("MovingDirection", 0);
                    break;
            }
        }
    
        public MovementState GetDirection(float horizontalInput, float verticalInput)
        {
            var horizontalInputString  = horizontalInput < 0 ? "-1" : horizontalInput > 0 ? "1" : "0";
            var verticalInputString = verticalInput < 0 ? "-1" : verticalInput > 0 ? "1" : "0";
            var keyString = horizontalInputString + "_" + verticalInputString;
            
            return MovementState.FromKey(keyString);
        }
    }
}
