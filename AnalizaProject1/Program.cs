namespace AnalizaProject1;

class Program
{
    //--------------------------------------------------------------
    static bool IsInputAvailable(string[] input)
    {
        return input.Length > 0;
    }

    //--------------------------------------------------------------
    static bool IsAllPositiveNum(string[] input)
    {
        foreach (string item in input)
            if (!item.All(char.IsDigit))
                return false;
        return true;
    }

    //--------------------------------------------------------------
    static bool IsThreePositiveNum(string[] input)
    {
        return input.Length >= 3;
    }

    //--------------------------------------------------------------
    static bool IsValidInput(string[] input)
    {
        return IsInputAvailable(input) && IsAllPositiveNum(input) && IsThreePositiveNum(input);
    }

    //--------------------------------------------------------------
    static string[] RunValidInputLoop(string[] input)
    {
        while (!IsValidInput(input))
        {
            Console.WriteLine("Invalid input.");
            input = GetNewInput();
        }
        return input;
    }

    //--------------------------------------------------------------
    static string[] GetNewInput()
    {
        Console.WriteLine("Please enter a series of at least 3 positive numbers:");
        return Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }

    //--------------------------------------------------------------
    static int[] ToIntArray(string[] input)
    {
        return input.Select(s => int.Parse(s)).ToArray();
    }

    //--------------------------------------------------------------
    static void PrintOrder(string[] input)
    {
        Console.WriteLine(string.Join(' ', input));
    }

    //--------------------------------------------------------------
    static void PrintReversed(string[] input)
    {
        Console.WriteLine(string.Join(' ', input.Reverse()));
    }

    //--------------------------------------------------------------
    static void PrintSorted(int[] input)
    {
        int[] sorted = (int[])input.Clone();
        Array.Sort(sorted);
        Console.WriteLine(string.Join(' ', sorted));
    }

    //--------------------------------------------------------------
    static int MaxArray(int[] input)
    {
        int max = input[0];
        foreach (int num in input)
            if (max < num)
                max = num;
        return max;
    }

    //--------------------------------------------------------------
    static int MinArray(int[] input)
    {
        int min = input[0];
        foreach (int num in input)
            if (min > num)
                min = num;
        return min;
    }

    //--------------------------------------------------------------
    static int SumArray(int[] input)
    {
        int sum = 0;
        foreach (int num in input)
            sum += num;
        return sum;
    }

    //--------------------------------------------------------------
    static int LenArray(int[] input)
    {
        return input.Length;
    }

    //--------------------------------------------------------------
    static float AvgArray(int[] input)
    {
        return (float)SumArray(input) / LenArray(input);
    }

    //--------------------------------------------------------------
    static void PrintMenu()
    {
        Console.WriteLine(@"
Menu:
1. Input a Series (replace the current series)
2. Display the series in the order it was entered
3. Display the series in the reversed order
4. Display the series in sorted order (from low to high)
5. Display the Max value of the series
6. Display the Min value of the series
7. Display the Average of the series
8. Display the Number of elements in the series
9. Display the Sum of the series
10. Exit
");
    }

    //--------------------------------------------------------------
    static (string[] updatedInput, bool keepRunning) RunMenu(string[] input)
    {
        PrintMenu();
        Console.Write("Enter your choice: ");

        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Invalid choice, please enter a number.");
            return (input, true);
        }

        switch (choice)
        {
            case 1:
                input = RunValidInputLoop(GetNewInput());
                break;
            case 2:
                PrintOrder(input);
                break;
            case 3:
                PrintReversed(input);
                break;
            case 4:
                PrintSorted(ToIntArray(input));
                break;
            case 5:
                Console.WriteLine($"Max is: {MaxArray(ToIntArray(input))}");
                break;
            case 6:
                Console.WriteLine($"Min is: {MinArray(ToIntArray(input))}");
                break;
            case 7:
                Console.WriteLine($"Average is: {AvgArray(ToIntArray(input))}");
                break;
            case 8:
                Console.WriteLine($"Length is: {LenArray(ToIntArray(input))}");
                break;
            case 9:
                Console.WriteLine($"Sum is: {SumArray(ToIntArray(input))}");
                break;
            case 10:
                Console.WriteLine("Exiting... Goodbye!");
                return (input, false);
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }

        return (input, true);
    }

    //--------------------------------------------------------------
    static void Main(string[] args)
    {
        args = RunValidInputLoop(args);
        bool keepRunning = true;

        while (keepRunning)
        {
            (args, keepRunning) = RunMenu(args);
        }
    }
}
