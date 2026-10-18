using System;

namespace TextShot
{
    class Program
    {
        public enum State
        {
            Start,              // Start of game
            Name,               // Entering Name
            RoundStart,         // Start of Round, Set Health, Empty Inventories
            LoadGun,            // Load gun
            PreTurnDecisions,   // Any events that need to be processed before next turn, then deciding whose turn
            PlayerTurn,         // Player chooses between using item or shooting gun
            PickItem,           // Pick Item
            DealerTurn,         // Start of Dealer's Turn
            DealerDecide,       // Dealer Decision Algorithm
            ShootGun,           // Use the gun to shoot, discard bullet
            RoundEnd,           // End of Round
            GameOver            // Show Stats, end program
        };

        // ================================
        // Initialise Variables
        // ================================

        // Player Command (Now static)
        static string Command = "";

        // Game States (Now static)
        public static State CurrentState = State.Start;
        public static State PrevState = State.Start;

        // Debug
        public static bool Debug = true;



        // ================================
        // Game Loop
        // ================================

        // Main method must be static
        public static void Main(string[] args)
        {
            while (true)
            {
                // State Change Handler
                if (CurrentState != PrevState)
                {
                    PrevState = CurrentState;
                    if (Debug) { Console.WriteLine($"State changed to {CurrentState}"); }
                }

                // Print commands
                Console.WriteLine("Commands:");
                Console.WriteLine("<>Commands here<>");

                // Read Command
                Program.Command = Console.ReadLine();

                Console.WriteLine(Program.Command);
                if (Program.Command == "exit")
                {
                    break;
                }
            }
        }
    }
}