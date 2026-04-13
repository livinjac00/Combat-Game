using System;

public class CombatEngine
{
    public static void PerformAttack(Player attacker, Player target)
    {
        Console.WriteLine($"\n{attacker.Name} ({attacker.PlayerCharacter.Name}) attacks {target.Name} ({target.PlayerCharacter.Name})!");
        
        int damage = attacker.PlayerCharacter.AttackDamage;
        
        // Basic elemental bonus logic for the mockup
        damage += attacker.PlayerCharacter.ElementDamageBonus;
        
        target.PlayerCharacter.TakeDamage(damage);

        if (target.PlayerCharacter.Health <= 0)
        {
            Console.WriteLine($"{target.Name} has been defeated!");
        }
    }
}
