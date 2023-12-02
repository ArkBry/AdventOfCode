using System.Runtime.CompilerServices;

string file = "C:\\Users\\brygo\\source\\repos\\AdventOfCode\\2023_02\\Input.txt";
//string file = "C:\\Users\\brygo\\source\\repos\\AdventOfCode\\2023_02\\TestInput.txt";




List<Game> game = Game.createFromFile(file);
// -------------------------------------------------  part 1 ------------------------------------
int totalGamePossible = 0;
foreach (var gameItem in game)
{
    if (gameItem.possible)
    {
        totalGamePossible += gameItem.gameNumber;
    }
}
Console.WriteLine($"Sum of total possible games id's is (part1):{totalGamePossible}");

// -------------------------------------------------  part 2 ------------------------------------
int minimalGame = 0;
foreach (var gameItem in game)
{
    foreach (var set in gameItem.sets)
    {
        if (set.red > gameItem.minRed) gameItem.minRed = set.red;
        if (set.green > gameItem.minGreen) gameItem.minGreen = set.green;
        if (set.blue > gameItem.minBlue) gameItem.minBlue = set.blue;
    }
    int i = gameItem.minRed * gameItem.minGreen * gameItem.minBlue;
    minimalGame += i;
//    Console.WriteLine($"red: {gameItem.minRed}, green{gameItem.minGreen}, blue{gameItem.minBlue}");
}
Console.WriteLine($"Sum of minimal colors is (part2):{minimalGame}");

public class Set
{
    public int red;
    public int green;
    public int blue;

    int maxRed = 12;
    int maxGreen = 13;
    int maxBlue = 14;

    public Set()
    {
        red = 0; green = 0; blue = 0;
    }
}

public class Game
{
    public int gameNumber;
    public bool possible;
    public List<Set> sets = new List<Set>();

    public int minRed = 0;
    public int minGreen = 0;
    public int minBlue = 0;

    public static int count = 0;

    public static List<Game> createFromFile(string file)
    {
        return File.ReadAllLines(file).Select(Game.convertToClass).ToList();
    }

    public static Game convertToClass(string line)
    {
        Game.count++;
        List<Set> sets = new List<Set>();
        int startingPoint = line.IndexOf(":") + 2;
        string lineTrimed = line.Substring(startingPoint); // lineTrimed contain only sets results

        string[] setString = lineTrimed.Split("; ");
        int i = 0;

        bool isPossible = true;

        foreach (string set in setString)
        {
            // Tutaj przeniesiono utworzenie nowego obiektu Set do pętli
            Set newSet = new Set { red = 0, blue = 0, green = 0 };
            sets.Add(newSet);

            string[] color = set.Split(", ");
            foreach (var item in color)
            {
                string[] column = item.Split(" ");
                if (column[1] == "red") newSet.red = int.Parse(column[0]);
                if (column[1] == "green") newSet.green = int.Parse(column[0]);
                if (column[1] == "blue") newSet.blue = int.Parse(column[0]);
            }
            if (newSet.red > 12 || newSet.green > 13 || newSet.blue > 14) isPossible = false;
            i++;
        }
        return new Game
        {
            gameNumber = Game.count,
            possible = isPossible,
            sets = sets // Dodano przypisanie listy sets do właściwości sets w klasie Game
        };
    }
}
