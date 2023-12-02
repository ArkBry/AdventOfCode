using System.Drawing;

string file = "C:\\Users\\brygo\\source\\repos\\AdventOfCode\\2015_02\\Input.txt";
List<Box> boxes = Box.ReadFromFile(file);

// -------------------------------------------------  part 1 ------------------------------------
foreach (Box box in boxes)
{
    box.AreaCalculaction();
}
//Console.WriteLine(boxes[0].a1 + " / " + boxes[0].a2 + " / " + boxes[0].a3 + " / " + boxes[0].smallest);
Console.WriteLine("Total area of paper (part1): " + Box.totalArea);

// -------------------------------------------------  part 2 ------------------------------------
foreach (Box box in boxes)
{
    box.LengthCalculation();
}
//Console.WriteLine(boxes[0].a1 + " / " + boxes[0].a2 + " / " + boxes[0].a3 + " / " + boxes[0].smallest);
Console.WriteLine("Total length of ribbon (part2): " + Box.totalLength);
public class Box
{
    public int x;
    public int y;
    public int z;

    public static int totalArea = 0;
    public static int totalLength = 0;

    public static Box ConvertToClass(string line)
    {
        var column = line.Split('x');
        return new Box
        {
            x = int.Parse(column[0]),
            y = int.Parse(column[1]),
            z = int.Parse(column[2])
        };
    }

    public static List<Box> ReadFromFile(string input)
    {
        return File.ReadAllLines(input).Where(line => line.Length > 1)
                               .Select(Box.ConvertToClass)
                               .ToList();
    }

    public void AreaCalculaction()
    {
        int a1;
        int a2;
        int a3;
        int smallest;

        a1 = x * y;
        a2 = x * z;
        a3 = y * z;

        smallest = a1;
        if (smallest > a2) smallest = a2;
        if (smallest > a3) smallest = a3;

        totalArea += 2 * a1 + 2 * a2 + 2 * a3 + smallest;
    }

    public void LengthCalculation()
    {
        int smallest1 = 0;
        int smallest2 = 0;
        int volume = x * y * z;

        smallest1 = x;
        smallest2 = y;

        smallest1 = Math.Min(Math.Min(x, y), z);

        if (smallest1 == x) { smallest2 = Math.Min(y, z); }
        else if (smallest1 == y) { smallest2 = Math.Min(z, x); }
        else if (smallest1 == z) { smallest2 = Math.Min(x, y); };

        totalLength += 2*smallest1 + 2*smallest2 + volume;
        
        
    }


}
