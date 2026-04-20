namespace Tests;

public class CombatLogicTests
{
    [Fact]
    public void HeavyAttackDealsExtraDamage()
    {
        Character attackerChar = new Character("Attacker", 100, 20, ElementType.Fire, 0, false);
        Character targetChar = new Character("Target", 100, 20, ElementType.Fire, 0, false);
        Player attacker = new Player(1, "Player 1", attackerChar);
        Player target = new Player(2, "Player 2", targetChar);

        // Heavy attack = 1.5 * base damage (20) = 30
        CombatEngine.PerformAttack(attacker, target, "Heavy Attack");

        Assert.Equal(70, targetChar.Health);
    }

    [Fact]
    public void LightAttackDealsReducedDamage()
    {
        Character attackerChar = new Character("Attacker", 100, 20, ElementType.Fire, 0, false);
        Character targetChar = new Character("Target", 100, 20, ElementType.Fire, 0, false);
        Player attacker = new Player(1, "Player 1", attackerChar);
        Player target = new Player(2, "Player 2", targetChar);

        // Light attack = 0.8 * base damage (20) = 16
        CombatEngine.PerformAttack(attacker, target, "Light attack");

        Assert.Equal(84, targetChar.Health);
    }

    [Fact]
    public void DodgeWorksProperly()
    {
        Character attackerChar = new Character("Attacker", 100, 20, ElementType.Fire, 0, false);
        Character targetChar = new Character("Target", 100, 20, ElementType.Fire, 0, false);
        Player attacker = new Player(1, "Player 1", attackerChar);
        Player target = new Player(2, "Player 2", targetChar);

        targetChar.IsDodging = true;

        CombatEngine.PerformAttack(attacker, target, "Heavy Attack");

        // Health should not change
        Assert.Equal(100, targetChar.Health);
        // IsDodging should be reset
        Assert.False(targetChar.IsDodging);
    }
}
