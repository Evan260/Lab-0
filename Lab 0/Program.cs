class Program
{
    static void Main()
    {
        int lowNumber = 0, highNumber = 0;
        while (lowNumber <= 0)
        {
            // Get low number from user
            Console.Write("Write the low number: ");
            string lowNumberInput = Console.ReadLine();
            lowNumber = ConvertStringToInt(lowNumberInput);
        }

        while (highNumber <= lowNumber)
        {
            // Get high number from user
            Console.Write("Write the high number: ");
            string highNumberInput = Console.ReadLine();
            highNumber = ConvertStringToInt(highNumberInput);

            if (highNumber <= lowNumber)
            {
                Console.WriteLine("Invalid input. The high number must be greater than the low number.");
            }
        }

        // Calculate
        int result = highNumber - lowNumber;
        Console.WriteLine($"Result: {result}");

        // Create an array of each number between low and high number
        int numberForArray = highNumber - lowNumber - 1;
        int[] array = new int[numberForArray];
        for (int i = 0; i < numberForArray; i++)
        {
            array[i] = i + lowNumber + 1;
        }

        // Write to file
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\numbers.txt";
        File.Create(filePath).Dispose();
        // Convert each element in the array to a string and reverse the order
        File.WriteAllLines(filePath, Array.ConvertAll(array.Reverse().ToArray(), x => x.ToString()));

        // Read file
        List<string> lines = File.ReadAllLines(filePath).ToList();

        // Convert string array to int array
        List<double> numbers = lines.Select(double.Parse).ToList();

        // Print sum
        Console.WriteLine($"Sum: {numbers.Sum()}");

        // Print prime numbers
        foreach (double number in numbers)
        {
            if (IsPrime(number)) { Console.WriteLine(number); }
        }
    }

    /// <summary>
    /// Converts a string to an integer, or -1 if invalid.
    /// </summary>
    static int ConvertStringToInt(string input)
    {
        if (int.TryParse(input, out int result))
        {
            return result;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return -1;
        }
    }
    static bool IsPrime(double number)
    {
        if (number <= 1)
        {
            return false;
        }
        if (number == 2)
        {
            return true;
        }

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}