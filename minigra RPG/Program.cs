Console.OutputEncoding = System.Text.Encoding.UTF8;

Random rnd = new Random();
List<Enemy> enemies = new List<Enemy>
{
    new Enemy("Goblin", rnd.Next(15, 31), 10, 10),
    new Enemy("Ork Lucznik", rnd.Next(15, 31), 15, 15),
    new Enemy("Ork Bandyta", rnd.Next(25, 46), 25, 20),
    new Enemy("Nietoperz", rnd.Next(5, 11), 2, 5),
    new Enemy("Troll", rnd.Next(45, 61), 25, 30),
    new Enemy("Szkielet", rnd.Next(20, 31), 10, 10),
    new Enemy("Smok", 120, 40, 100)
};
List<Player> players = new List<Player>
{
    new Player("Elyndra", "Zielarka", "Biegła w sztuce ziołolecznictwa, wspiera drużynę bogatym zapasem leczniczych mikstur. Choć jej ciosy są słabe, potrafi ocalić towarzyszy w najtrudniejszej chwili.", 0, 0, 100, 50, 10, 0, 10),
    new Player("Tharok", "Rycerz", "Odważny rycerz, który sprawnie włada mieczem i osłania towarzyszy. Ciężka zbroja pozwala mu wytrwać w samym sercu bitwy.", 0, 0, 100, 100, 3, 0, 20),
    new Player("Sylvar", "Krasnolud", "Wytrzymały krasnolud, którego potężny topór kruszy pancerze wrogów. Duża żywotność i miażdżące ciosy okupione są powolnością, przez którą rzadziej unika ataków.", 0, 0, 100, 120, 5, 0, 15),
    new Player("Kaelthorn", "Mag", "Mistrz niszczycielskich zaklęć, który razi przeciwników potężną magią. Spora żywotność pozwala mu przetrwać starcie i kontynuować rzucanie czarów.", 0, 0, 100, 80, 5, 0, 30),
    new Player("Morgath", "Elf", "Zwinny elf o pewnej ręce i sokolim wzroku, mistrzowsko władający łukiem. Szybki refleks pozwala mu unikać ciosów i celnie razić wrogów z dystansu.", 0, 0, 100, 100, 3, 0, 25)
};
List<int> colors = new List<int> { 1, 2, 3, 4, 5, 6 };
List<Player> team = new List<Player>
{
    
};
foreach (Player player in players)
{
    int color = colors[rnd.Next(colors.Count)];
    colors.Remove(color);
    Console.ForegroundColor = (ConsoleColor)color;
    Console.WriteLine(new string('=', 60));
    Console.ResetColor();
    Console.WriteLine($"{player.Name} — {player.Rank}");
    Console.ForegroundColor = (ConsoleColor)color;
    Console.WriteLine(new string('-', 60));
    Console.ResetColor();
    
    string line = "";
    foreach (string word in player.Description.Split(' ', StringSplitOptions.RemoveEmptyEntries))
    {
        if (line.Length > 0 && line.Length + word.Length + 1 > 60)
        {
            Console.WriteLine(line);
            line = "";
        }

        line += (line.Length > 0 ? " " : "") + word;
    }
    Console.WriteLine(line);

    Console.ForegroundColor = (ConsoleColor)color;
    Console.WriteLine(new string('-', 60));
    Console.ResetColor();
    Console.WriteLine($"Poziom:              {player.Level}");
    Console.WriteLine($"Doświadczenie:       {player.XP} / {player.MaxXP}");
    Console.WriteLine($"Punkty życia:        {player.Health} / {player.MaxHealth}");
    Console.WriteLine($"Siła:                {player.Strength}");
    Console.WriteLine($"Zasoby lecznicze:    {player.Medicine}");
    Console.ForegroundColor = (ConsoleColor)color;
    Console.WriteLine(new string('=', 60));
    Console.ResetColor();
    Console.WriteLine();
}
// character selection system
Console.WriteLine("Wybierz trzech bohaterów do swojej drużyny. Podaj imiona:");
bool choose = false;
bool repeat = false;
bool choose3 = false;
string characters = "";
while (!choose)
{
    characters = Console.ReadLine()!;
    if (characters.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length != 3)
    {
        Console.WriteLine("Nieprawidłowa liczba bohaterów.");
        continue;
    }
    choose3 = false;
    repeat = false;
    foreach (string character in characters.Split(' ', StringSplitOptions.RemoveEmptyEntries))
    {
        foreach (Player player in players)
        {
            if (character == player.Name)
            {
                if (team.Contains(player))
                {
                    Console.WriteLine("Bohaterowie nie mogą się powtarzać.");
                    choose3 = false;
                    repeat = true;
                    break;
                }
                else
                {
                    team.Add(player);
                    choose3 = true;
                    break;
                }
            }
        }
        if (!choose3)
        {
            team.Clear();
            break;
        }
    }
    if (choose3)
    {
        choose = true;
    }
    else if (repeat)
    {
        
    }
    else
    {
        Console.WriteLine("Nieprawidłowa nazwa bohatera.");
    }
}
Console.WriteLine("\nTwoja Drużna:\n");
foreach (string character in characters.Split(' ', StringSplitOptions.RemoveEmptyEntries))
{
    Console.WriteLine($"{character}");
}

bool gameOn = true;
int stage = 1;
while (gameOn)
{
    Console.Clear();
    Console.Write("\u001b[3J");
    Console.WriteLine($"\nPOZIOM {stage}/5\n");
    List<Enemy> stageEnemies = GetStageEnemies(stage);
    bool options = true;
    while (options)
    {
        Console.WriteLine("[1] WALKA");
        Console.WriteLine("[2] ULEPSZENIA POSTACI");
        Console.WriteLine("[3] INFORMACJE O DRUŻYNIE");
        string option = Console.ReadLine();
        Console.WriteLine();
        switch (option)
        {
            case "1":
                options = false;
                break;
            case "2":
                upgrates();
                break;
            case "3":
                foreach (Player player in team)
                {
                    Console.WriteLine($"\n{player.Name} — {player.Rank}");
                    Console.WriteLine($"Poziom:              {player.Level}");
                    Console.WriteLine($"Doświadczenie:       {player.XP} / {player.MaxXP}");
                    Console.WriteLine($"Punkty życia:        {player.Health} / {player.MaxHealth}");
                    Console.WriteLine($"Siła:                {player.Strength}");
                    Console.WriteLine($"Zasoby lecznicze:    {player.Medicine}");
                    Console.WriteLine($"Punkty do ulepszeń:  {player.XpPoints}");
                }
                Console.WriteLine();
                break;
            default:
                Console.WriteLine("Nieprawidłowa opcja");
                break;
        }
    }

    Console.Clear();
    Console.Write("\u001b[3J");
    Console.WriteLine("Rozpoczynanie walki...");
    System.Threading.Thread.Sleep(3000);

    bool battleWon = false;
    while (true)
    {
        bool enemiesAlive = false;
        foreach (Enemy enemy in stageEnemies)
        {
            if (enemy.IsAlive())
            {
                enemiesAlive = true;
                break;
            }
        }

        if (!enemiesAlive)
        {
            battleWon = true;
            break;
        }

        Console.WriteLine("\n--- TURA BOHATERÓW ---");
        foreach (Player player in team)
        {
            if (!player.IsAlive())
            {
                continue;
            }

            List<Enemy> livingEnemies = new List<Enemy>();
            foreach (Enemy enemy in stageEnemies)
            {
                if (enemy.IsAlive())
                {
                    livingEnemies.Add(enemy);
                }
            }

            if (livingEnemies.Count == 0)
            {
                break;
            }

            int targetIndex = 0;
            while (targetIndex < 1 || targetIndex > livingEnemies.Count)
            {
                for (int i = 0; i < livingEnemies.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {livingEnemies[i].Name} — {livingEnemies[i].Health}/{livingEnemies[i].MaxHealth} HP");
                }

                Console.WriteLine($"Wybierz cel dla {player.Name}:");
                string targetChoice = Console.ReadLine();
                Console.WriteLine();
                if (!int.TryParse(targetChoice, out targetIndex) || targetIndex < 1 || targetIndex > livingEnemies.Count)
                {
                    Console.WriteLine("Nieprawidłowy wybór celu.");
                    targetIndex = 0;
                }
            }

            Enemy target = livingEnemies[targetIndex - 1];
            int minDamage = Math.Max(1, player.Strength * 80 / 100);
            int maxDamage = Math.Max(minDamage, player.Strength * 120 / 100);
            int damage = rnd.Next(minDamage, maxDamage + 1);

            target.TakeDamage(damage);
            Console.WriteLine($"\n{player.Name} zadaje {damage} obrażeń przeciwnikowi {target.Name}.");

            if (!target.IsAlive())
            {
                Console.WriteLine($"\n{target.Name} został pokonany. {player.Name} zdobywa {target.XpReward} XP.");
                player.GainXp(target.XpReward);
            }
        }

        Console.WriteLine("\n--- TURA PRZECIWNIKÓW ---");
        foreach (Enemy enemy in stageEnemies)
        {
            if (!enemy.IsAlive())
            {
                continue;
            }

            List<Player> livingPlayers = new List<Player>();
            foreach (Player player in team)
            {
                if (player.IsAlive())
                {
                    livingPlayers.Add(player);
                }
            }

            if (livingPlayers.Count == 0)
            {
                break;
            }

            Player enemyTarget = livingPlayers[rnd.Next(livingPlayers.Count)];
            enemyTarget.TakeDamage(enemy.Damage);
            Console.WriteLine($"\n{enemy.Name} zadaje {enemy.Damage} obrażeń bohaterowi {enemyTarget.Name}.");
        }

        bool playersAlive = false;
        foreach (Player player in team)
        {
            if (player.IsAlive())
            {
                playersAlive = true;
                break;
            }
        }

        if (!playersAlive)
        {
            break;
        }
    }

    if (battleWon)
    {
        Console.WriteLine("\nDrużyna wygrała walkę!");
        if (stage == 5)
        {
            Console.WriteLine("Smok został pokonany. Gra ukończona!");
            gameOn = false;
        }
        else
        {
            stage++;
        }
        System.Threading.Thread.Sleep(3000);
    }
    else
    {
        Console.WriteLine("\nCała drużyna została pokonana. Koniec gry.");
        gameOn = false;
    }
}

List<Enemy> GetStageEnemies(int currentStage)
{
    if (currentStage == 5)
    {
        Enemy dragon = enemies.Find(enemy => enemy.Name == "Smok")!;
        return new List<Enemy> { new Enemy(dragon.Name, dragon.MaxHealth, dragon.Damage, dragon.XpReward) };
    }

    string[] enemyNames;
    int enemyCount;

    if (currentStage == 1)
    {
        enemyNames = new[] { "Nietoperz", "Goblin", "Szkielet" };
        enemyCount = 2;
    }
    else if (currentStage == 2 || currentStage == 3)
    {
        enemyNames = new[] { "Ork Lucznik", "Ork Bandyta" };
        enemyCount = currentStage == 2 ? 2 : 3;
    }
    else
    {
        enemyNames = new[] { "Ork Bandyta", "Troll" };
        enemyCount = 3;
    }

    List<Enemy> selectedEnemies = new List<Enemy>();
    for (int i = 0; i < enemyCount; i++)
    {
        string enemyName = enemyNames[rnd.Next(enemyNames.Length)];
        Enemy selectedEnemy = enemies.Find(enemy => enemy.Name == enemyName)!;
        selectedEnemies.Add(new Enemy(selectedEnemy.Name, selectedEnemy.MaxHealth, selectedEnemy.Damage, selectedEnemy.XpReward));
    }

    return selectedEnemies;
}

void upgrates()
{
    bool upgrading = true;
    while (upgrading)
    {
        foreach (Player player in team)
        {
            Console.WriteLine($"{player.Name}");
            Console.WriteLine($"Punkty do wykorzystania: {player.XpPoints}");
            Console.WriteLine($"Punkty życia: {player.Health}/{player.MaxHealth}");
            Console.WriteLine($"Siła:  {player.Strength}");
        }

        Console.WriteLine();
        for (int i = 0; i < team.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {team[i].Name}");
        }

        Console.WriteLine("[4] Wyjdź");
        string option = Console.ReadLine();
        Console.WriteLine();
        switch (option)
        {
            case "4":
                Console.Clear();
                Console.Write("\u001b[3J");
                upgrading = false;
                break;
            case "1":
                if (team[0].XpPoints > 0)
                {
                    bool chooseUpgrade = true;
                    while (chooseUpgrade)
                    {
                        Console.WriteLine("[1] Ulepszenie punktów życia");
                        Console.WriteLine("[2] Ulepszenie siły");
                        Console.WriteLine("[3] Wyjście");
                        string upgradeOption = Console.ReadLine();
                        Console.WriteLine();
                        if (upgradeOption == "1" && team[0].XpPoints > 0)
                        {
                            team[0].Health += 20;
                            team[0].MaxHealth += 20;
                            team[0].XpPoints -= 1;
                        }
                        else if (upgradeOption == "2" && team[0].XpPoints > 0)
                        {
                            team[0].Strength += 10;
                            team[0].XpPoints -= 1;
                        }
                        else if (upgradeOption == "3")
                        {
                            chooseUpgrade = false;
                        }
                        else if ((upgradeOption == "1" || upgradeOption == "2") && team[0].XpPoints <= 0)
                        {
                            Console.WriteLine("Nie masz punktów do wykorzystania.");
                        }
                        else
                        {
                            Console.WriteLine("BŁĄD");
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{team[0].Name} ma zero punktów i nie może wejść do ulepszeń.");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                break;
            case "2":
                if (team[1].XpPoints > 0)
                {
                    bool chooseUpgrade = true;
                    while (chooseUpgrade)
                    {
                        Console.WriteLine("[1] Ulepszenie punktów życia");
                        Console.WriteLine("[2] Ulepszenie siły");
                        Console.WriteLine("[3] Wyjście");
                        string upgradeOption = Console.ReadLine();
                        Console.WriteLine();
                        if (upgradeOption == "1" && team[1].XpPoints > 0)
                        {
                            team[1].Health += 20;
                            team[1].MaxHealth += 20;
                            team[1].XpPoints -= 1;
                        }
                        else if (upgradeOption == "2" && team[1].XpPoints > 0)
                        {
                            team[1].Strength += 10;
                            team[1].XpPoints -= 1;
                        }
                        else if (upgradeOption == "3")
                        {
                            chooseUpgrade = false;
                        }
                        else if ((upgradeOption == "1" || upgradeOption == "2") && team[1].XpPoints <= 0)
                        {
                            Console.WriteLine("Nie masz punktów do wykorzystania.");
                        }
                        else
                        {
                            Console.WriteLine("BŁĄD");
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{team[1].Name} ma zero punktów i nie może wejść do ulepszeń.");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                break;
            case "3":
                if (team[2].XpPoints > 0)
                {
                    bool chooseUpgrade = true;
                    while (chooseUpgrade)
                    {
                        Console.WriteLine("[1] Ulepszenie punktów życia");
                        Console.WriteLine("[2] Ulepszenie siły");
                        Console.WriteLine("[3] Wyjście");
                        string upgradeOption = Console.ReadLine();
                        Console.WriteLine();
                        if (upgradeOption == "1" && team[2].XpPoints > 0)
                        {
                            team[2].Health += 20;
                            team[2].MaxHealth += 20;
                            team[2].XpPoints -= 1;
                        }
                        else if (upgradeOption == "2" && team[2].XpPoints > 0)
                        {
                            team[2].Strength += 10;
                            team[2].XpPoints -= 1;
                        }
                        else if (upgradeOption == "3")
                        {
                            chooseUpgrade = false;
                        }
                        else if ((upgradeOption == "1" || upgradeOption == "2") && team[2].XpPoints <= 0)
                        {
                            Console.WriteLine("Nie masz punktów do wykorzystania.");
                        }
                        else
                        {
                            Console.WriteLine("BŁĄD");
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{team[2].Name} ma zero punktów i nie może wejść do ulepszeń.");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                break;
        }
    }
}

// TODO: Dodać możliwość używania mikstur leczniczych podczas gry.
