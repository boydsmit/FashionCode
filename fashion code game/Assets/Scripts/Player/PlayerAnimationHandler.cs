        using UnityEngine;

namespace Player
{
    public class PlayerAnimationHandler : MonoBehaviour
    {
        
        public void SetPlayerAnimation(float horizontalInput, float verticalInput)
        {
            var movementState = GetDirection(horizontalInput, verticalInput);
            switch (movementState.DisplayValue)
            { 
                case "Idle":    
                    break;
                case "Up":
                    break;
                case "Down":
                    break;
                case "Left":
                    break;
                case "Right":
                    break;
                case "UpRight":
                    break;
                case "UpLeft":
                    break;
                case "DownRight":
                    break;
                case "DownLeft":
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
