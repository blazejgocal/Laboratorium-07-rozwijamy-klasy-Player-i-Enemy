Player player = new Player("Maciuś", 10, 50, 100, 100, 100, 50);
Enemy enemy = new Enemy("Goblin",  50, 10);

Console.WriteLine($"{player.Name} spotyka {enemy.Name}a");
bool graTrwa = true;
while (graTrwa)
{
    Console.WriteLine($"Punkty Życia: {player.Health}/{player.MaxHealth}");
    Console.WriteLine("Co zrobić? atak/leczenie");
    if (Console.ReadLine() == "atak")
    {
        enemy.TakeDamage(player.Damage);
        if (!enemy.IsAlive())
        {
            graTrwa = false;
            Console.WriteLine("Gracz Wygrywa.");
            break;
        }
    }
    else if (Console.ReadLine() == "leczenie")
    {
        player.Heal(20);
    }
    else
    {
        Console.WriteLine("Czynność nieznana.");
    }
    Console.WriteLine("Goblin atakuje!");
    player.TakeDamage(enemy.Damage);
    if (!player.IsAlive())
    {
        graTrwa = false;
        Console.WriteLine("Przeciwnik Wygrywa.");
    }
}