public class Player
{
    public string Name { get; }
    public int Level { get; set; }
    public int XP { get; set; }
    public int MaxXP { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Damage { get; set; }

    public Player(string name, int level, int xp, int maxXP, int health, int maxHealth, int damage)
    {
        Name = name;
        Level = level;
        XP = xp;
        MaxXP = maxXP;
        Health = health;
        MaxHealth = maxHealth;
        Damage =  damage;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0)
        {
            Health = 0;
        }
    }

    public void Heal(int amount)
    {
        Health += amount;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
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
        MaxHealth += 20;
        Health += 20;
        Damage += 20;
    }
}