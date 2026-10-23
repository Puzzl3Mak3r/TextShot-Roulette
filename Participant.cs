using System;
using System.Collections.Generic;

namespace TextShot
{
    public class Participant
    {
        private Inventory _inventory;
        private string _name;
        private int _health;

        public Participant(string name, int health)
        {
            _inventory = new Inventory();
            _name = name;
            _health = health;
        }

        public Inventory Inventory { get => _inventory; set => _inventory = value; }
        public string Name { get => _name; set => _name = value; }
        public int Health { get => _health; set => _health = value; }

        public void PrintInventory()
        {
            _inventory.ReadItems();
        }

        public void ClearInventory()
        {
            Inventory.ClearOutInventory();
            if (Program.Debug) Console.WriteLine($"Debug {Name}'s Inventory cleared");
        }
    }
}