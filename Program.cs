using System;

namespace TextShot
{
    class Program
    {
        public enum State
        {
            Start,          // Start of game
            Name,           // Entering Name
            StartRound,     // Start of Round
            PickItem,       // Pick Item
            DealerTurn,     // Start of Dealer's Turn
            DealerDecide,   // Dealer Decision Algorithm
            EndRound,       // End of Round
            GameOver        // Show Stats, end program
        };

        // ================================
        // Initialise Variables
        // ================================

        // Player Command (Now static)
        static string Command = "";

        // Game States (Now static)
        public static State CurrentState = State.Start;
        public static State PrevState = State.Start;

        // ================================
        // Game Loop
        // ================================

        // Main method must be static
        public static void Main(string[] args)
        {
            while (true)
            {
                // Print commands

                // Read Command (Handle possible null reference)
                Program.Command = Console.ReadLine() ?? "";

                Console.WriteLine(Program.Command);
                if (Program.Command == "exit")
                {
                    break;
                }
            }
        }
    }
}