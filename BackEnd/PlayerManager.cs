using System;
using System.Collections.Generic;

public static class PlayerManager
{
    private static List<Player> _players = new List<Player>();
    public static IReadOnlyList<Player> Players => _players;

    public static void SetupPlayers(int count)
    {
        _players.Clear();
        for (int i = 1; i <= count; i++)
        {
            Console.Write($"Enter name for Player {i}: ");
            string name = Console.ReadLine() ?? $"Player {i}";
            
            // For the prototype, we initialize with no character selected
            // Character selection would happen in a separate step
            _players.Add(new Player(i, name, null!));
            Console.WriteLine($"Player {i} set as: {name}");
        }
    }

    public static void DisplayPlayers()
    {
        Console.WriteLine("\nCurrent Players:");
        foreach (var player in _players)
        {
            Console.WriteLine($"ID: {player.PlayerNumber} | Name: {player.Name}");
        }
    }
}
