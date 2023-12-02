string input;

//Console.WriteLine("Provide input data:\n");
//input=Console.ReadLine();
input = "((())))";

int floor = 0;
int counter = 0;

// -------------------------------------------------  part 1 ------------------------------------
foreach (char item in input)
{
    if (item == '(') floor++;
    else if (item == ')') floor--;
}
Console.WriteLine("Actual floor (part1): "+ floor);

// -------------------------------------------------  part 2 ------------------------------------
floor = 0;
counter = 0;

bool basement = false;
foreach (char item in input)
{
    counter++;

    if (item == '(') floor++;
    else if (item == ')') floor--;

    if (floor == -1)
    {
        Console.WriteLine("First basement (part2): " + counter);
        basement = true;
        break;
    }
}
if (basement == false) Console.WriteLine("No basement reached  (part2)");

Console.WriteLine();
return 0;


// answer 1: 74
// answer 2: 1795