namespace AnalizaProject1;

class Program
{
    static bool IsInputAvailable(string[] input)
    {
        return input.Length > 0;
    }

    static bool IsAllPositiveNum(string[] input)
    {
        foreach (string item in input)
            if (!item.All(char.IsDigit))
                return false;    
        return true;
    }

    static bool IsThreePositiveNum(string[] input)
    {
        return input.Length >= 3;
    }

    static bool IsValidInput(string[] input)
    {
        return IsInputAvailable(input) && IsAllPositiveNum(input) && IsThreePositiveNum(input);
    }

    static string [] RumValidInputLoop(string[] input)
    {
        while (!IsValidInput(input))
        {
            Console.WriteLine("invalid input");
            input = GetNewInput();
        }
        return input;
    }

    static string[] GetNewInput()
    {
        Console.WriteLine("Please enter a series of at least positive number");
        string[] numbers = Console.ReadLine().Split(' ');
        return numbers;
    }
    
    static int[] ToIntArray(string[] input)
    {
        int[] asIntegers = input.Select(s => int.Parse(s)).ToArray();
        return asIntegers;
    }

    static void PrintOrder(string[] input)
    {
        foreach (string item in input)
            Console.Write(item + " ");
        Console.WriteLine();
    }

    static void PrintReversed(string[] input)
    {
        for (int i = input.Length - 1; i >= 0; i--)
            Console.Write(input[i] + " ");
        Console.WriteLine();
    }
    static void PrintSorted(int[] input)
    {
        int[] sorted = (int[])input.Clone(); 
        Array.Sort(sorted);                  

        foreach (int num in sorted)
            Console.Write(num + " ");
        Console.WriteLine();
    }

    static int MaxArray(int[] input)
    {
        int max = 0;
        foreach (int num in input)
            if (max < num)
                max = num;
        return max;
    }
    static int MinArray(int[] input)
    {
        int min = int.MaxValue;
        foreach (int num in input)
            if (min > num)
                min = num; 
        return min;
    }

    static int SumArray(int[] input)
    {
        int sum = 0;
        foreach (int num in input)
            sum += num;
        return sum;
    }

    static int LenArray(int [] input)
    {
        return input.Length;
    }

    static float AvgArray(int[] input)
    {
        return (float)SumArray(input) / LenArray(input);
    }

    static void PrintMenu()
    {
        Console.WriteLine(@"menu:
        1. Input a Series. (Replace the current series)
        2. Display the series in the order it was entered.
        3. Display the series in the reversed order it was entered.
        4. Display the series in sorted order (from low to high).
        5. Display the Max value of the series.
        6. Display the Min value of the series.
        7. Display the Average of the series.
        8. Display the Number of elements in the series.
        9. Display the Sum of the series.
        10. Exit.");
    }
    
    

    static string[] RumMenu(string[] input)
    {
        PrintMenu();
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                input = RumValidInputLoop(GetNewInput());
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
                Console.WriteLine($"max is = :{MaxArray(ToIntArray(input))}");
                break;
            case 6:
                Console.WriteLine($"min is = :{MinArray(ToIntArray(input))}");
                break;
            case 7:
                Console.WriteLine($"average is = :{AvgArray(ToIntArray(input))}");
                break;
            case 8:
                Console.WriteLine($"len is = :{LenArray(ToIntArray(input))}");
                break;
            case 9:
                Console.WriteLine($"sum is = :{SumArray(ToIntArray(input))}");
                break;
            case 10:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("error");
                break; 
        }
        return input;

    }

    static void Main(string[] args)
    {
        args = RumValidInputLoop(args);
        while (true)
        {
           args = RumMenu(args);
        } 
    }
}