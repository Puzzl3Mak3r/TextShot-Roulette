using System;

namespace TextShot
{
    public class MagnifyingGlass : Item
    {
        public MagnifyingGlass() : base("Magnifying Glass", "See what bullet is in the cartridge")
        {}
        
        override public void ExecuteEffect()
        {
            base.ExecuteEffect();
        }
    }
}