string file = "C:\\Users\\brygo\\source\\repos\\AdventOfCode\\2015_03\\Input.txt";
string input = File.ReadAllText(file);


List<House> houses = new List<House>();
int xPos = 0;
int yPos = 0;

houses.Add(new House { x = xPos, y = yPos }); // starting point

foreach (char item in input) 
{
    if (item == '^') yPos--;
    else if (item == 'v') yPos++;
    else if (item == '<') xPos--;
    else if (item == '>') xPos++;

    houses.Add(new House { x = xPos, y = yPos });   
}

Console.WriteLine(houses.Count);

public class House
{
    public int? x = null;
    public int? y = null;
}