using System;
using System.Collections.Generic;

public static class CharacterSelection
{
    public static List<Character> AvailableCharacters { get; private set; }
    private static List<Player> _players = new List<Player>();
    public static IReadOnlyList<Player> Players => _players;

    static CharacterSelection()
    {
        // Initialize with some default mockup characters
        AvailableCharacters = new List<Character>
        {
            new Character("Fire Knight", 100, 20, ElementType.Fire, 5),
            new Character("Water Mage", 80, 15, ElementType.Water, 10),
            new Character("Earth Guardian", 120, 10, ElementType.Earth, 2),
            new Character("Air Scout", 90, 18, ElementType.Air, 4)
        };
    }

    /// <summary>
    /// Sets up players by asking for names and then letting them pick a character.
    /// </summary>
    public static void SetupGame(int playerCount)
    {
        _players.Clear();
        for (int i = 1; i <= playerCount; i++)
        {
            Console.WriteLine($"\n--- Player {i} Setup ---");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine() ?? $"Player {i}";

            DisplayAvailableCharacters();
            Console.Write("Choose a character (enter number): ");
            
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice < AvailableCharacters.Count)
            {
                var selected = AvailableCharacters[choice];
                _players.Add(new Player(i, name, selected));
                Console.WriteLine($"Player {i} set as {name} using {selected.Name}!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Assigning first character by default.");
                _players.Add(new Player(i, name, AvailableCharacters[0]));
            }
        }
    }

    public static void DisplayAvailableCharacters()
    {
        Console.WriteLine("\nAvailable Characters:");
        for (int i = 0; i < AvailableCharacters.Count; i++)
        {
            var c = AvailableCharacters[i];
            Console.WriteLine($"{i}: {c.Name} (Health: {c.Health}, Element: {c.Element})");
        }
    }

    public static void DisplayCurrentPlayers()
    {
        Console.WriteLine("\nFinal Setup:");
        foreach (var p in _players)
        {
            Console.WriteLine($"P{p.PlayerNumber}: {p.Name} as {p.PlayerCharacter.Name}");
        }
    }
}
