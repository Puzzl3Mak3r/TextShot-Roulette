using System;

namespace TextShot
{
    public class Item
    {
        private string _name;
        private string _description;
        public Item(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public string Name { get { return _name; } }
        public string Description { get { return _description; } }

        public virtual void ExecuteEffect()
        {
            if (Program.Debug)
            {
                Console.WriteLine($"Debug Effect Executed of Item: {Name}");
            }
        }
    }
}