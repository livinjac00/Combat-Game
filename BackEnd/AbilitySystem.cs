using System;
using System.Collections.Generic;

namespace BackEnd;

public static class AbilitySystem
{
    public static List<string> MovementOptions = new List<string> { "Advance", "Retreat", "Dodge" };

    public static List<string> AttackTypes = new List<string> { "Heavy Attack", "Light attack", "Elemental attack" };

    public static void PerformMovement(Player player)
    {
        Console.WriteLine($"\n--- {player.Name}'s Move Phase ---");
        for (int i = 0; i < MovementOptions.Count; i++)
        {
            Console.WriteLine($"{i}: {MovementOptions[i]}");
        }
        Console.WriteLine("Select movement (0-2):");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice < MovementOptions.Count)
        {
            string selectedMove = MovementOptions[choice];
            Console.WriteLine($"{player.Name} chose to {selectedMove}!");
            
            // Movement effects
            switch (selectedMove)
            {
                case "Advance":
                    Console.WriteLine("Effect: Moving closer! Attack damage slightly increased for this turn.");
                    player.PlayerCharacter.AttackDamage += 2; // buff?
                    break;
                case "Retreat":
                    Console.WriteLine("Effect: Backing away. Evasion increased for this turn!");
                    player.PlayerCharacter.IsDodging = true; // dodge effect
                    break;
                case "Dodge":
                    Console.WriteLine("Effect: Evasive stance! Will dodge the next attack.");
                    player.PlayerCharacter.IsDodging = true;
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Skipping movement phase.");
        }
    }

    public static void PerformAbility(Player attacker, Player target)
    {
        Console.WriteLine($"\n--- {attacker.Name}'s Attack Phase ---");
        for (int i = 0; i < AttackTypes.Count; i++)
        {
            Console.WriteLine($"{i}: {AttackTypes[i]}");
        }
        Console.WriteLine("Select attack (0-2):");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice < AttackTypes.Count)
        {
            string selectedAttack = AttackTypes[choice];
            Console.WriteLine($"{attacker.Name} used {selectedAttack}!");
            
            // attack through CombatEngine with the selected attack type
            CombatEngine.PerformAttack(attacker, target, selectedAttack);
        }
        else
        {
            Console.WriteLine("Invalid choice. Skipping attack phase.");
        }
    }
}
