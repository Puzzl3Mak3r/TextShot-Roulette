using System;

namespace TextShot
{
    class Program
    {
        // ================================
        // State Machine
        // ================================

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

        // Game States
        public static State CurrentState = State.Start;
        public static State PrevState = State.Start;





        // =====================
        // Debug
        public static bool Debug = true;




        // Main method must be static
        public static void Main(string[] args)
        {
            // ================================
            // Initialise Variables
            // ================================

            // =====================
            // Game Variables

            // New Random
            Random r = new Random();


            // =====================
            // Player & Dealer Variables

            // Player Name
            string PlayerName = "";

            // Player & Dealer Health
            int pHealth;
            int dHealth;

            // Player Command (Now static)
            string Command = "";





            // ================================
            // Game Loop
            // ================================

            // Item test = new InfectedBullet();
            while (true)
            {
                // State Change Handler
                if (CurrentState != PrevState)
                {
                    PrevState = CurrentState;
                    if (Debug) { Console.WriteLine($"State changed to {CurrentState}"); }
                }

                // // Print commands
                // Console.WriteLine("Commands:");
                // Console.WriteLine("<>Commands here<>");

                // // Read Command
                // Program.Command = Console.ReadLine();

                // Console.WriteLine(Program.Command);
                // if (Program.Command == "item")
                // {
                //     test.ExecuteEffect();
                // }
                // else if (Program.Command == "exit")
                // {
                //     break;
                // }





                // ================================
                // State Machine
                // ================================

                // ================================
                // Start
                if (CurrentState == State.Start)
                {
                    // Start Game
                    CurrentState = State.Name;

                    // Add a few lines to seperate
                    Console.WriteLine("\n\n\n");
                }
                
                // ================================
                // Name
                else if (CurrentState == State.Name)
                {
                    // Enter Name
                    Console.WriteLine("Enter Name:");
                    PlayerName = Console.ReadLine();
                    if (Debug) { Console.WriteLine($"Name Entered: {PlayerName}"); }

                    // Dealer Greeting Message
                    Console.WriteLine($"Greetings, {PlayerName}\nI hope you know how to play");

                    // Dev Breakpoint
                    if (PlayerName == "dev") { break; }

                    // Transition to RoundStart
                    CurrentState = State.RoundStart;
                }

                // ================================
                // Round Start
                else if (CurrentState == State.RoundStart)
                {
                    // Set Health
                    pHealth = r.Next(3,5);
                    dHealth = pHealth;
                    Console.WriteLine($"{pHealth} health");
                    if (Debug) { Console.WriteLine($"Player {pHealth}, Dealer {dHealth}"); }

                    // Empty Inventories
                    Inventory playerInventory = new Inventory();
                    Inventory dealerInventory = new Inventory();

                    // Populate Inventories
                    playerInventory.PopulateInventory(3);
                    dealerInventory.PopulateInventory(3);

                    // Transition to LoadGun
                    CurrentState = State.LoadGun;
                }
            }
        }
    }
}