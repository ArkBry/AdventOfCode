string input;

Console.WriteLine("Podaj dane:\n");
//input=Console.ReadLine();
input = "((()";

int floor = 0;

foreach (char item in input)
{
    if (item =='(') floor++;
    else if (item ==')') floor--;
}
Console.WriteLine(floor);
return 0;

// answer: 74