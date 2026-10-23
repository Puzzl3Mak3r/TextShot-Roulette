using System;
using System.Collections.Generic;

namespace TextShot
{
    public class Gun
    {
        private bool[] _bullets;
        private int _liveBullets;
        private int _dudBullets;
        Random r = new Random();

        public Gun(int n)
        {
            _bullets = new bool[n];
        }

        public void Load(int n)
        {
            // Initialize random number of bullets
            _bullets = new bool[n];
            if (Program.Debug) { Console.WriteLine($"Debug Loaded {_bullets.Length} bullets"); }

            // Guarantee at least 1 live and 1 dud
            _liveBullets = r.Next(1, _bullets.Length);
            _dudBullets = _bullets.Length - _liveBullets;

            // Fill the array with the chosen amount of live bullets first
            for (int i = 0; i < _bullets.Length; i++)
            {
                _bullets[i] = (i < _liveBullets); 
            }
        }

        public void Shuffle()
        {
            // Shuffle the array to randomize bullet order (Fisher-Yates shuffle)
            for (int i = 0; i < _bullets.Length; i++)
            {
                int randomIndex = r.Next(i, _bullets.Length);
                bool temp = _bullets[i];
                _bullets[i] = _bullets[randomIndex];
                _bullets[randomIndex] = temp;
                
                if (Program.Debug) { Console.WriteLine($"Debug Bullet {i}: {_bullets[i]}"); }
            }
        }

        public void PrintLoadout()
        {
            // Print amount of live bullets
            if (_liveBullets == 1)
            { Console.WriteLine($"{_liveBullets} live bullet"); }
            else
            { Console.WriteLine($"{_liveBullets} live bullets"); }

            // Print amount of dud bullets
            if (_dudBullets == 1)
            { Console.WriteLine($"{_dudBullets} dud bullet"); }
            else
            { Console.WriteLine($"{_dudBullets} dud bullets"); }
        }
    }
}