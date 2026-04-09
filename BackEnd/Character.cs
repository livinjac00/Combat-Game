public class Character
{
    public string Name{ get; set;}
    public int Health{ get; set;}
    // Attack damage and elemental damage can be hard coded
    public int AttackDamage{ get; set;}
    public ElementType Element{ get; set;}
    public int ElementDamageBonus{ get; set;}

    public Character(string name, int health, int attackDamage, ElementType element, int elementDamageBonus)
    {
        Name = name;
        Health = health;
        AttackDamage = attackDamage;
        Element = element;
        ElementDamageBonus = elementDamageBonus;
    }
}