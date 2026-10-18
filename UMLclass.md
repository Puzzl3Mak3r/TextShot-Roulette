```mermaid
classDiagram
    class Program {
        +Main(string[] args)$ void
    }

    class GameController {
        -string _command
        +State CurrentState
        +State PrevState
        +Player HumanPlayer
        +Dealer AIDealer
        +StartGame() void
        +ProcessCommand(string input) void
        +NextRound() void
    }

    class State {
        <<enumeration>>
        Start
        Name
        StartRound
        PickItem
        DealerTurn
        DealerDecide
        EndRound
        GameOver
    }

    class Participant {
        <<abstract>>
        +string Name
        +int Health
        +List~Item~ Inventory
        +AddItem(Item item) void
        +UseItem(int index, Participant target) void
    }

    class Player {
        +int Wins
        +int Losses
        +ShowStats() string
    }

    class Dealer {
        +MakeDecision(Participant opponent) void
    }

    class Item {
        <<abstract>>
        +string Name
        +string Description
        +ExecuteEffect(Participant user, Participant target)* void
    }

    class Infected Bullet{
        <<abstracted>>
        +Override Name
        +Override Description
        +Override ExecuteEffect()
    }

    class Magnifying Glass{
        <<abstracted>>
        +Override Name
        +Override Description
        +Override ExecuteEffect()
    }

    class Bugged CircuitBoard{
        <<abstracted>>
        +Override Name
        +Override Description
        +Override ExecuteEffect()
    }

    class Expired Medicine{
        <<abstracted>>
        +Override Name
        +Override Description
        +Override ExecuteEffect()
    }

    class Hand Cuffs{
        <<abstracted>>
        +Override Name
        +Override Description
        +Override ExecuteEffect()
    }

    class Can Of Beer{
        <<abstracted>>
        +Override Name
        +Override Description
        +Override ExecuteEffect()
    }

    Program --> GameController : initializes
    GameController --> State : tracks
    GameController *-- Player : manages
    GameController *-- Dealer : manages
    Participant <|-- Player : inherits
    Participant <|-- Dealer : inherits
    Participant o-- Item : holds
    Infected Bullet <-- Item : abstracts
    Magnifying Glass <-- Item : abstracts
    Item --> Bugged CircuitBoard : abstracts
    Item --> Expired Medicine : abstracts
    Item --> Hand Cuffs : abstracts
    Item --> Can Of Beer : abstracts
    ```