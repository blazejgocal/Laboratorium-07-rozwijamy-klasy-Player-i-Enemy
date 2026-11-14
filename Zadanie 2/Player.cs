public class Player
{
    public string Name { get; }
    public string Rank { get; }
    public string Description { get; }
    public int Level { get; set; }
    public int XP { get; set; }
    public int MaxXP { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Damage { get; set; }
    public int Medicine { get; set; }
    public int XpPoints { get; set; }

    public Player(string name, string rank, string description, int level, int xp, int maxXP, int maxHealth, int medicine, int xpPoints )
    {
        Name = name;
        Rank = rank;
        Description = description;
        Level = level;
        XP = xp;
        MaxXP = maxXP;
        Health = maxHealth;
        MaxHealth = maxHealth;
        Medicine = medicine;
        XpPoints = xpPoints;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            Console.WriteLine("damage amount invalid");
        }
        else
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }
    }

    public void Heal(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("heal amount invalid");
        }
        else
        {
            Health += amount;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }
    }

    public bool IsAlive()
    {
        return Health > 0;
    }
    
    public void GainXp(int xp)
    {
        XP += xp;
        if  (XP >= MaxXP)
        {
            XP -= MaxXP;
            NewXpLevel();
        }
    }
    
    public void NewXpLevel()
    {
        Level += 1;
        XpPoints += 1;
    }
}