using System;

namespace TextShot
{
    public class BuggedCircuitBoard : Item
    {
        public BuggedCircuitBoard() : base("Bugged Circuit Board", "Swaps your and the dealer's inventories")
        {}
        
        override public void ExecuteEffect()
        {
            base.ExecuteEffect();
        }
    }
}