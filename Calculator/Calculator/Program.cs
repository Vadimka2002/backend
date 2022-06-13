namespace Application
{
    class Program
    {
        static int Main()
        {
            try
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    throw new ApplicationException("Invalid input data");
                }

                var result = Calculator.Calculator.Calculate(input);
                Console.WriteLine(result);
                return 0;

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                return 1;
            }
        }
    }
}