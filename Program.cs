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
            ExplainGame,        // Explains the game
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



        public static void Main(string[] args)
        {
            // ================================
            // Initialise Variables
            // ================================

            // =====================
            // Game Variables

            // New Random
            Random r = new Random();

            // Gun
            Gun gun = null;


            // =====================
            // Player & Dealer Variables

            // Participants
            Player p;
            Dealer d;

            // Player Command
            string Command = "";

            // Player Name
            string PlayerName = "";

            // Player & Dealer Health
            int Health;





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
                    if (Debug) { Console.WriteLine($"\nDebug State changed to {CurrentState}\n"); }
                }





                // ===============================
                // Test State Machine
                // ===============================

                // Test Code here





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
                    if (Debug) { Console.WriteLine($"Debug Name Entered: {PlayerName}"); }

                    // Dealer Greeting Message
                    Console.WriteLine($"\nGreetings, {PlayerName}\nI hope you know how to play (Y/n)");

                    // Dev Breakpoint
                    if (PlayerName == "dev") { break; }

                    // Transition to RoundStart
                    string knowGame = Console.ReadLine().ToLower();
                    while (knowGame != "y" && knowGame != "n" && knowGame != "yes" && knowGame != "no")
                    {
                        if (Debug) { Console.WriteLine($"Debug Invalid Input: {knowGame}"); }
                        Console.WriteLine("Please answer yes or no\n no means I will explain the game");
                        knowGame = Console.ReadLine().ToLower();
                    }
                    if (knowGame == "n" || knowGame == "no")
                    {
                        CurrentState = State.ExplainGame;
                    }
                    else
                    {
                        CurrentState = State.RoundStart;
                    }
                }



                // ================================
                // Explain Game
                else if (CurrentState == State.ExplainGame)
                {
                    Console.WriteLine("You and I take turns using a gun.\nThe gun has a random assortment of live bullets and dud bullets.\n(Press Enter to continue)");
                    Console.ReadLine();
                    Console.WriteLine("Each turn, you can use any items if we have any.\nItems can help your chances of survival, or decrease mine.\n(Press Enter to continue)");
                    Console.ReadLine();
                    Console.WriteLine("You can look at your items from your inventory.\n(Press Enter to continue)");
                    Console.ReadLine();
                    Console.WriteLine("You can also look at the my (the dealer) items.\nYou can also look at our healths.\n(Press Enter to continue)");
                    Console.ReadLine();
                    Console.WriteLine("You can either shoot me, or yourself.\n(Press Enter to continue)");
                    Console.ReadLine();
                    Console.WriteLine("If you shoot yourself, and it's a dud, you don't lose any health and it's your turn again.\nSame goes for me.\n(Press Enter to continue)");
                    Console.ReadLine();
                    Console.WriteLine("The first one to have their health reach 0 loses");
                    Console.ReadLine();
                    Console.WriteLine("Are you ready? (Y/n)");
                    string ready = Console.ReadLine().ToLower();
                    while (ready != "y" && ready != "n" && ready != "yes" && ready != "no")
                    {
                        if (Debug) { Console.WriteLine($"Debug Invalid Input: {ready}"); }
                        Console.WriteLine("Please answer yes or no.\n No means I will explain the game");
                        ready = Console.ReadLine().ToLower();
                    }
                    if (ready == "n" || ready == "no")
                    {
                        CurrentState = State.ExplainGame;
                    }
                    CurrentState = State.RoundStart;
                }



                // ================================
                // Round Start
                else if (CurrentState == State.RoundStart)
                {
                    // New Random
                    r = new Random();

                    // Set Health
                    Health = r.Next(3,5);

                    // Create Participants
                    p = new Player(PlayerName, Health);
                    d = new Dealer("Dealer", Health);
                    Console.WriteLine($"You and I have {Health} health");
                    if (Debug) { Console.WriteLine($"Debug Player {Health} health, Dealer {Health} health"); }

                    // Empty Inventories
                    p.ClearInventory();
                    d.ClearInventory();

                    // Populate Inventories
                    int InveAmount = r.Next(2, 5);
                    p.Inventory.PopulateInventory(InveAmount);
                    d.Inventory.PopulateInventory(InveAmount);

                    // Transition to LoadGun
                    Console.ReadLine();
                    CurrentState = State.LoadGun;
                }



                // ================================
                // Load Gun
                else if (CurrentState == State.LoadGun)
                {
                    // Load the gun
                    int numOfBullets = r.Next(2, 8);
                    gun = new Gun(numOfBullets);
                    gun.Load(numOfBullets);

                    // Shuffle the array to randomize bullet order (Fisher-Yates shuffle)
                    gun.Shuffle();

                    // Print amount of live bullets
                    gun.PrintLoadout();

                    // Flavour text
                    Console.ReadLine();
                    Console.WriteLine("They enter the gun in an unknown order");

                    // Transition to PreTurnDecisions
                    Console.ReadLine();
                    CurrentState = State.PreTurnDecisions;
                    break;
                }
            }
        }
    }
}