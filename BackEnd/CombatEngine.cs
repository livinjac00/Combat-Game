using System;

public static class CombatEngine 
{
    
    public static void PerformAttack(Player attacker, Player target, string attackType = "Normal")
    {
        Console.WriteLine($"\n{attacker.Name} ({attacker.PlayerCharacter.Name}) used {attackType} on {target.Name} ({target.PlayerCharacter.Name})!");
        
        int damage = attacker.PlayerCharacter.AttackDamage;
        
        
        switch (attackType)
        {
            case "Heavy Attack":
                damage = (int)(damage * 1.5);
                Console.WriteLine("A powerful blow!");
                break;
            case "Light attack":
                damage = (int)(damage * 0.8);
                Console.WriteLine("A quick strike!");
                break;
            case "Elemental attack":
                damage += attacker.PlayerCharacter.ElementDamageBonus * 2;
                Console.WriteLine($"The power of {attacker.PlayerCharacter.Element} surges!");
                break;
            default:
                damage += attacker.PlayerCharacter.ElementDamageBonus;
                break;
        }
        
        target.PlayerCharacter.TakeDamage(damage);

        if (target.PlayerCharacter.Health <= 0)
        {
            Console.WriteLine($"{target.Name} has been defeated!");
        }
    }

    
    public static void AttackPlayer(Character AttackingPlayer, Character DefendingPlayer) 
    {
        DefendingPlayer.Health = DefendingPlayer.Health - AttackingPlayer.AttackDamage;
    }
}
