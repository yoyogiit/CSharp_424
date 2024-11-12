namespace Lab1App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // generates a secret number ranging between 0 and 99, inclusive
            Random rng = new Random();
            int SecretNum = rng.Next(0, 100);
            int lower = 0, upper = 99;

            // asks the player to guess a number.
            Console.WriteLine("({0}, {1})?", lower, upper);
            int guess = int.Parse(Console.ReadLine());

            while (upper > lower)
            {
                if (guess == SecretNum)
                {
                    Console.WriteLine("Bingo!");
                    break;
                }
                else if (guess < SecretNum)
                {
                    lower = guess + 1;
                    Console.WriteLine("({0}, {1})?", lower, upper);
                }
                else
                {
                    upper = guess - 1;
                    Console.WriteLine("({0}, {1})?", lower, upper);
                }

                if (lower == upper)
                {
                    Console.WriteLine("GG!");
                    break;
                }
            }
        }
    }
}
