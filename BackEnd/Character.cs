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

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
        
        Console.WriteLine($"{Name} took {damage} damage!");
        DisplayHealthBar();
    }

    public void DisplayHealthBar()
    {
        int barLength = 20;
        // Assuming 100 is the base max health for the mockup
        int filledLength = (int)((double)Health / 100 * barLength);
        if (filledLength < 0) filledLength = 0;
        if (filledLength > barLength) filledLength = barLength;

        string bar = new string('█', filledLength) + new string('-', barLength - filledLength);
        Console.WriteLine($"{Name} HP: [{bar}] {Health}");
    }
}