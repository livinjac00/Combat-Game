public class Character
{
    public string Name{ get; set;}
    public int Health{ get; set;}
    
    public int AttackDamage{ get; set;}
    public int BaseAttackDamage { get; set; }
    public ElementType Element{ get; set;}
    public int ElementDamageBonus{ get; set;}
    public bool IsDodging { get; set; } = false;
    public bool IsSelected { get; set; } = false;

    public Character(string name, int health, int attackDamage, ElementType element, int elementDamageBonus, bool isSelected)
    {
        Name = name;
        Health = health;
        AttackDamage = attackDamage;
        BaseAttackDamage = attackDamage;
        Element = element;
        ElementDamageBonus = elementDamageBonus;
        IsSelected = isSelected;
    }

    public void TakeDamage(int damage)
    {
        if (IsDodging)
        {
            Console.WriteLine($"{Name} dodged the attack!");
            IsDodging = false; // Reset dodge after one use
            return;
        }

        Health -= damage;
        if (Health < 0) Health = 0;
        
        Console.WriteLine($"{Name} took {damage} damage!");
        DisplayHealthBar();
    }

    public void ResetStatus()
    {
        IsDodging = false;
        AttackDamage = BaseAttackDamage;
    }

    public void DisplayHealthBar()
    {
        int barLength = 20;
        // 100 is the base max health 
        int filledLength = (int)((double)Health / 100 * barLength);
        if (filledLength < 0) filledLength = 0;
        if (filledLength > barLength) filledLength = barLength;

        string bar = new string('█', filledLength) + new string('-', barLength - filledLength);
        Console.WriteLine($"{Name} HP: [{bar}] {Health}");
    }
}