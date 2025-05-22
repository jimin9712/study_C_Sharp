namespace Break
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("계속할까요?(y/n)");
                string answer = Console.ReadLine();

                if (answer == "n")
                    break;
            }
        }
    }
}
