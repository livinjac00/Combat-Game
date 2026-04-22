using System;
using System.Security.AccessControl;

namespace BackEnd;

public static class GameEngine
{
    public static List<Character> Characters { get; set; } = new List<Character> {
        new Character("Fire Knight", 100, 20, ElementType.Fire, 5, false),
        new Character("Water Mage", 100, 20, ElementType.Water, 5, false),
        new Character("Earth Barbarian", 100, 20, ElementType.Earth, 5, false),
        new Character("Air Archer", 100, 20, ElementType.Air, 5, false)
    };

    public static Player Player1 { get; set; } = new Player(1, string.Empty, null);
    public static Player Player2 { get; set; } = new Player(2, string.Empty, null);


    public static void StartGame()
    {
        Console.WriteLine("Welcome to the Combat Game!");
        
        
        CharacterSelection.SetupGame(2);
        
        var players = CharacterSelection.Players;
        if (players.Count < 2)
        {
            Console.WriteLine("Not enough players to start.");
            return;
        }

        bool gameRunning = true;
        int round = 1;

        while (gameRunning)
        {
            Console.WriteLine($"\n========== Round {round} ==========");
            
            // Player 1 Turn
            ExecuteTurn(players[0], players[1]);
            if (players[1].PlayerCharacter.Health <= 0)
            {
                Console.WriteLine($"\n{players[0].Name} Wins!");
                gameRunning = false;
                break;
            }

            // Player 2 Turn
            ExecuteTurn(players[1], players[0]);
            if (players[0].PlayerCharacter.Health <= 0)
            {
                Console.WriteLine($"\n{players[1].Name} Wins!");
                gameRunning = false;
                break;
            }

            round++;
            if (round > 20) 
            {
                Console.WriteLine("Game reached maximum rounds. It's a draw!");
                gameRunning = false;
            }
        }

        Console.WriteLine("\nGame Over! Thanks for playing.");
    }

    private static void ExecuteTurn(Player activePlayer, Player opponent)
    {
        Console.WriteLine($"\n>>> {activePlayer.Name}'s Turn <<<");
        
        
        activePlayer.Move();
        
        
        activePlayer.Attack(opponent);
        
        // End of turn cleanup: reset buffs and dodging status
        activePlayer.PlayerCharacter.ResetStatus();
    }
}
