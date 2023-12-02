string input;

Console.WriteLine("Podaj dane:\n");
//input=Console.ReadLine();
input = "()()(";

int floor = 0;
int counter = 0;

foreach (char item in input)
{
    counter++;

    if (item == '(') floor++;
    else if (item == ')') floor--;
 
    if (floor == -1)
    {
        Console.WriteLine(counter);
        break;
    }
}

return 0;
// answer: 1795
