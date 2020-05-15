using System.Linq;

namespace Player
{
    public class MovementState
    {
        private static readonly MovementState Idle = new MovementState("Idle", "0_0");
        private static readonly MovementState Up =  new MovementState("Up", "1_1");
        private static readonly MovementState Down = new MovementState("Down", "-1_-1");
        private static readonly MovementState Left = new MovementState("Left", "-1_1");
        private static readonly MovementState Right = new MovementState("Right", "1_-1");

        
        private readonly string _displayValue;
        private readonly string _key;
        private static readonly MovementState[] All =  {Idle,Up, Down, Left, Right};

        private MovementState(string displayValue, string key)
        {
            _displayValue = displayValue;
            _key = key;
        }

        public static MovementState FromKey(string key)
        {
            return All.First(c => c._key == key);
        }
        
        public string DisplayValue
        {
            get { return _displayValue; }
        }

        public string Key
        {
            get { return _key; }
        }
    }
}