using System.Linq;

namespace Player
{
    public class MovementState
    {
        public static readonly MovementState Idle = new MovementState("Idle", "0_0");
        public static readonly MovementState Up =  new MovementState("Up", "0_1");
        public static readonly MovementState Down = new MovementState("Down", "0_-1");
        public static readonly MovementState Left = new MovementState("Left", "-1_0");
        public static readonly MovementState Right = new MovementState("Right", "1_0");
        public static readonly MovementState UpLeft = new MovementState("UpLeft", "-1_1");
        public static readonly MovementState UpRight = new MovementState("UpRight", "1_1");
        public static readonly MovementState DownLeft = new MovementState("UpLeft", "-1_-1");
        public static readonly MovementState DownRight = new MovementState("UpRight","1_-1");
        
        private readonly string _displayValue;
        private readonly string _key;
        private static readonly MovementState[] All = new[] {Idle,Up, Down, Left, Right, UpLeft, UpRight, DownLeft, DownRight};

        private MovementState(string displayValue, string key)
        {
            _displayValue = displayValue;
            _key = key;
        }

        public static MovementState FromValue(string moveState)
        {
            return All.First(c => c._displayValue == moveState);
        }

        public static MovementState FromKey(string key)
        {
            return All.First(c => c._key == key);
        }

        public static string[] values
        {
            get { return All.Select(c => c.DisplayValue).ToArray(); }
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