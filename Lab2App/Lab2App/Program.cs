namespace Lab2App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of citizens:");
            int N = int.Parse(Console.ReadLine());

            Console.Write("ID: ");
            for (int i = 0; i < N; i++)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();

            Console.Write("Contactee: ");
            int[] x = new int[N];
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                int j = random.Next(i, N);
                int temp = x[i];
                x[i] = x[j];
                x[j] = temp;
            }
            foreach (int temp in x)
            {
                Console.Write("{0} ", temp);
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Enter id of infected citizen:");
            int infected = int.Parse(Console.ReadLine());

            Console.WriteLine("These citizens are to be self-isolated in the following 14 days:");
            int iso = x[0];
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == iso)
                {
                    iso = x[i];
                }
            }
            Console.WriteLine("{0} ", iso);

        }
    }
}
