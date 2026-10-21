using System;

namespace TextShot
{
    public class CanOfBeer : Item
    {
        public CanOfBeer() : base("Can Of Beer", "Removes the current bullet without using it")
        {}
        
        override public void ExecuteEffect()
        {
            base.ExecuteEffect();
        }
    }
}