Console.OutputEncoding = System.Text.Encoding.UTF8;

Random rnd = new Random();
List<Enemy> enemies = new List<Enemy>
{
    new Enemy("Goblin", rnd.Next(15, 31), 10),
    new Enemy("Ork Lucznik", rnd.Next(15, 31), 15),
    new Enemy("Ork Bandyta", rnd.Next(25, 46), 25),
    new Enemy("Nietoperz", rnd.Next(5, 11), 2),
    new Enemy("Troll", rnd.Next(45, 61), 25),
    new Enemy("Szkielet", rnd.Next(20, 31), 10),
    new Enemy("Smok", 120, 40)
};
List<Player> players = new List<Player>
{
    new Player("Elyndra", "Zielarka", "Biegła w sztuce ziołolecznictwa, wspiera drużynę bogatym zapasem leczniczych mikstur. Choć jej ciosy są słabe, potrafi ocalić towarzyszy w najtrudniejszej chwili.", 0, 0, 100, 50, 10, 0),
    new Player("Tharok", "Rycerz", "Odważny rycerz, który sprawnie włada mieczem i osłania towarzyszy. Ciężka zbroja pozwala mu wytrwać w samym sercu bitwy.", 0, 0, 100, 100, 3, 0),
    new Player("Sylvar", "Krasnolud", "Wytrzymały krasnolud, którego potężny topór kruszy pancerze wrogów. Duża żywotność i miażdżące ciosy okupione są powolnością, przez którą rzadziej unika ataków.", 0, 0, 100, 120, 5, 0),
    new Player("Kaelthorn", "Mag", "Mistrz niszczycielskich zaklęć, który razi przeciwników potężną magią. Spora żywotność pozwala mu przetrwać starcie i kontynuować rzucanie czarów.", 0, 0, 100, 80, 5, 0),
    new Player("Morgath", "Elf", "Zwinny elf o pewnej ręce i sokolim wzroku, mistrzowsko władający łukiem. Szybki refleks pozwala mu unikać ciosów i celnie razić wrogów z dystansu.", 0, 0, 100, 100, 3, 0)
};
List<int> colors = new List<int> { 1, 2, 3, 4, 5, 6 };
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

    // Zawijanie opisu do krótkich wierszy bez dzielenia słów.
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
    Console.WriteLine($"Obrażenia:           {player.Damage}");
    Console.WriteLine($"Zasoby lecznicze:    {player.Medicine}");
    Console.ForegroundColor = (ConsoleColor)color;
    Console.WriteLine(new string('=', 60));
    Console.ResetColor();
    Console.WriteLine();
}

Console.WriteLine("Wybierz trzech bohaterów do swojej drużyny. Podaj imiona:");
bool choose = false;
bool choose2 = false;
bool choose3 = false;
string characters = "";
while (!choose)
{
    characters = Console.ReadLine()!;
    choose2 = false;
    foreach (string character in characters.Split(' ', StringSplitOptions.RemoveEmptyEntries))
    {
        choose3 = false;
        if (character != "Elyndra" && character != "Tharok" && character != "Sylvar" && character != "Kaelthorn" &&
            character != "Morgath")
        {
            Console.WriteLine("Błąd imion bohaterów, podaj prawidłowe imiona.");
            choose3 = false;
            break;
        }
        else
        {
            choose3 = true;
        }
    }
    if (choose3)
    {
        choose2 = true;
    }
    if (choose2)
    {
        choose = true;
    }
}
Console.WriteLine("\nTwoja Drużna: ");
foreach (string character in characters.Split(' ', StringSplitOptions.RemoveEmptyEntries))
{
    Console.WriteLine($"{character}");
}

bool gameOn = true;
int stage = 1;
while (gameOn)
{
    Console.WriteLine($"POZIOM {stage}/5\n");
    Console.WriteLine("Statystyki bohaterów drużyny:\n");
    Console.WriteLine("");
    foreach (string character in characters.Split(' ', StringSplitOptions.RemoveEmptyEntries))
    {
        foreach (Player player in players)
        {
            if (character == player.Name)
            {
                Console.WriteLine($"{player.Name} — {player.Rank}");
                Console.WriteLine($"Poziom:              {player.Level}");
                Console.WriteLine($"Doświadczenie:       {player.XP} / {player.MaxXP}");
                Console.WriteLine($"Punkty życia:        {player.Health} / {player.MaxHealth}");
                Console.WriteLine($"Obrażenia:           {player.Damage}");
                Console.WriteLine($"Zasoby lecznicze:    {player.Medicine}");
                Console.WriteLine("");
            }
        }
    }
    

    gameOn = false;
}
