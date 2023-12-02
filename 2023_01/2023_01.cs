string file = "C:\\Users\\brygo\\source\\repos\\AdventOfCode\\2023_01\\Input.txt";
//string file = "C:\\Users\\brygo\\source\\repos\\AdventOfCode\\2023_01\\TestInput.txt";

List<Calibration1> calibrations1 = Calibration1.createFromFile(file);
List<Calibration2> calibrations2 = Calibration2.createFromFile(file);


// -------------------------------------------------  part 1 ------------------------------------

foreach (var item in calibrations1)
{
    Calibration1.sumTotal(item.calibrationValue);
}
Console.WriteLine("Total calibration value (part1): " + Calibration1.totalAmount);

// -------------------------------------------------  part 2 ------------------------------------
foreach (var item in calibrations2)
{
    Calibration2.sumTotal(item.calibrationValue);
}
Console.WriteLine("Total corrected calibration value (part2): " + Calibration2.totalAmount);
public class Calibration1
{
    public int calibrationValue;
    public static int totalAmount = 0;

    public static List<Calibration1> createFromFile(string file)
    {
        return File.ReadAllLines(file).Where(line => line.Length > 1)
                                      .Select(Calibration1.convertToClass)
                                      .ToList();
    }

    public static Calibration1 convertToClass(string line)
    {
        bool firstFlag = true;

        char? firstDigit = '0';
        char? lastDigit = null;

        foreach (char actualChar in line)
        {
            if (char.IsDigit(actualChar))
            {
                if (firstFlag)
                {
                    firstDigit = actualChar;
                    lastDigit = actualChar;
                    firstFlag = false;
                }
                else
                {
                    lastDigit = actualChar;
                }
            }
        }
        return new Calibration1
        {
            calibrationValue = int.Parse($"{firstDigit}{lastDigit}")
        };
    }

    public static void sumTotal(int cal)
    {
        totalAmount += cal;
    }
}

public class Calibration2
{
    public int calibrationValue;
    public static int totalAmount = 0;
    public static Dictionary<string, char> spelled = new Dictionary<string, char>();
    public static List<Calibration2> createFromFile(string file)
    {
        Calibration2.createSpelled();
        return File.ReadAllLines(file).Where(line => line.Length > 1)
                                      .Select(Calibration2.convertToClass)
                                      .ToList();
    }

    public static Calibration2 convertToClass(string line)
    {
        bool firstFlag = true;

        char? firstDigit = '0';
        char? lastDigit = null;

        for (int i = 0; i <= line.Length - 1; i++)
        {
            if (char.IsDigit(line[i]))
            // loop when number is a digit
            {
                if (firstFlag)
                {
                    firstDigit = line[i];
                    lastDigit = line[i];
                    firstFlag = false;
                }
                else
                {
                    lastDigit = line[i];
                }
            }
            else
            // loop when number is spelled out
            {
                foreach (var item in spelled)
                {
                    if (line.Substring(i).StartsWith(item.Key))
                    {
                        if (firstFlag)
                        {
                            firstDigit = item.Value;
                            lastDigit = item.Value;
                            firstFlag = false;
                        }
                        else
                        { lastDigit = item.Value; }

                    }

                }
            }
        }
        //       Console.WriteLine($"{firstDigit}{lastDigit}");  // test each line callibration values

        return new Calibration2
        {
            calibrationValue = int.Parse($"{firstDigit}{lastDigit}")
        };
    }

    public static void sumTotal(int cal)
    {
        totalAmount += cal;
    }

    public static void createSpelled()
    {
        spelled.Add("one", '1');
        spelled.Add("two", '2');
        spelled.Add("three", '3');
        spelled.Add("four", '4');
        spelled.Add("five", '5');
        spelled.Add("six", '6');
        spelled.Add("seven", '7');
        spelled.Add("eight", '8');
        spelled.Add("nine", '9');
    }
}