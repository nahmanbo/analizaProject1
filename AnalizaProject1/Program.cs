namespace AnalizaProject1;

class Program
{
    bool isInputAvailable(string[] input)
    {
        return input.Length > 0;
    }

    bool isAllNumbers(string[] input)
    {
        foreach (string item in input)
            if (!item.All(char.IsDigit))
                return false;    
        return true;
    }

    bool isThreePositiveNum(string[] input)
    {
        int counter = 0;
        foreach (string item in input)
            if(Convert.ToInt32(item) > 0)
                counter++;
            if(counter == 3)
                return true;
        return false;
    }
    
    static void Main(string[] args)
    {
    }
}