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

            // Gun
            bool[] gun;


            // =====================
            // Player & Dealer Variables

            // Player Name
            string PlayerName = "";

            // Player & Dealer Health
            int pHealth;
            int dHealth;

            // Player Command (Now static)
            string Command = "";

            // Inventories
            Inventory pInventory = new Inventory();
            Inventory dInventory = new Inventory();
            int InveAmount; // Amount of items in inventory




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
                    Console.WriteLine($"\nGreetings, {PlayerName}\nI hope you know how to play");

                    // Dev Breakpoint
                    if (PlayerName == "dev") { break; }

                    // Transition to RoundStart
                    Console.ReadLine();
                    CurrentState = State.RoundStart;
                }

                // ================================
                // Round Start
                else if (CurrentState == State.RoundStart)
                {
                    // New Random
                    r = new Random();

                    // Set Health
                    pHealth = r.Next(3,5);
                    dHealth = pHealth;
                    Console.WriteLine($"{pHealth} health");
                    if (Debug) { Console.WriteLine($"Player {pHealth}, Dealer {dHealth}"); }

                    // Empty Inventories
                    pInventory = new Inventory();
                    dInventory = new Inventory();

                    // Populate Inventories
                    InveAmount = r.Next(2, 5);
                    pInventory.PopulateInventory(InveAmount);
                    dInventory.PopulateInventory(InveAmount);

                    // Transition to LoadGun
                    Console.ReadLine();
                    CurrentState = State.LoadGun;
                }
                else if (CurrentState == State.LoadGun)
                {
                    // Load the gun
                    gun = new bool[r.Next(2, 8)]; // Random number of bullets
                    if (Debug) { Console.WriteLine($"\nLoaded {gun.Length} bullets"); }

                    // Guarantee at least 1 live and 1 dud by picking a live count between 1 and Length-1
                    int liveBullets = r.Next(1, gun.Length);

                    // Fill the array with the chosen amount of live bullets first
                    for (int i = 0; i < gun.Length; i++)
                    {
                        gun[i] = (i < liveBullets); 
                    }

                    // Shuffle the array to randomize bullet order (Fisher-Yates shuffle)
                    for (int i = 0; i < gun.Length; i++)
                    {
                        int randomIndex = r.Next(i, gun.Length);
                        bool temp = gun[i];
                        gun[i] = gun[randomIndex];
                        gun[randomIndex] = temp;
                        
                        if (Debug) { Console.WriteLine($"Bullet {i}: {gun[i]}"); }
                    }

                    // Print amount of live bullets
                    if (liveBullets == 1)
                    { Console.WriteLine($"{liveBullets} live"); }
                    else
                    { Console.WriteLine($"{liveBullets} lives"); }

                    // Print amount of dud bullets
                    if (gun.Length - liveBullets == 1)
                    { Console.WriteLine($"{gun.Length - liveBullets} dud"); }
                    else
                    { Console.WriteLine($"{gun.Length - liveBullets} duds"); }

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