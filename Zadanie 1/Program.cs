Player player = new Player("Maciuś", 10, 50, 100, 100, 100, 50);
Console.WriteLine($"Cześć {player.Name}");
Console.WriteLine("Zdobywasz 50 punktów doświadczenia");
player.GainXp(50);

Console.WriteLine("Imie: " + player.Name);
Console.WriteLine("Poziom: " + player.Level);
Console.WriteLine($"XP: {player.XP}/{player.MaxXP}");
Console.WriteLine($"Punkty Zdrowia: {player.Health}/{player.MaxHealth}");
Console.WriteLine("Obrażenia: " + player.Damage);