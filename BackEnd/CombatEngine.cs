public static class CombatEngine //made static to be able to access the methods more easily
{

    public static void AttackPlayer(Character AttackingPlayer, Character DefendingPlayer) //Handles Basic Player Damage
    {
        DefendingPlayer.Health = DefendingPlayer.Health - AttackingPlayer.AttackDamage;
    }




}