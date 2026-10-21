using System;

namespace TextShot
{
    public class InfectedBullet : Item
    {
        public InfectedBullet() : base("Infected Bullet", "Infected Bullet")
        {

        }
        
        override public void ExecuteEffect()
        {
            if (Program.Debug)
            {
                Console.WriteLine($"Effect Executed of InfectedBullet: {Name}");
            }
        }
    }
}