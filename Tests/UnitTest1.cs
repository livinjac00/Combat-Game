namespace Tests;

public class UnitTest1
{
    [Fact]
    public void PlayerAttack()
    {
        Character character = new Character("Bob", 100, 10, ElementType.Fire, 5);
        Character enemyCharacter = new Character("Enemey", 100, 10, ElementType.Fire, 5);

        CombatEngine.AttackPlayer(character, enemyCharacter);

        Assert.Equal(90, enemyCharacter.Health);
    }
}
