using System;

namespace TextShot
{
    public class ExpiredMedicine : Item
    {
        public ExpiredMedicine() : base("Expired Medicine", "50% chance of healing 1 health point, or damages 1 health point")
        {}
        
        override public void ExecuteEffect()
        {
            base.ExecuteEffect();
        }
    }
}