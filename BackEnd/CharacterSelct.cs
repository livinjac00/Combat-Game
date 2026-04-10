using System;
using System.Collections.Generic;

public static class CharacterSelection
{
    public static List<Character> AvailableCharacters { get; private set; }
    public static Character SelectedCharacter { get; private set; }

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

    public static void SelectCharacter(int index)
    {
        if (index >= 0 && index < AvailableCharacters.Count)
        {
            SelectedCharacter = AvailableCharacters[index];
            Console.WriteLine($"Selected character: {SelectedCharacter.Name}");
        }
    }

    public static void DisplayAvailableCharacters()
    {
        Console.WriteLine("Available Characters:");
        for (int i = 0; i < AvailableCharacters.Count; i++)
        {
            var c = AvailableCharacters[i];
            Console.WriteLine($"{i}: {c.Name} (Health: {c.Health}, Element: {c.Element})");
        }
    }
}
