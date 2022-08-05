namespace NoJump
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool enabled = false;
            bool invalidKey = false;
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("Z key = ENABLE");
            Console.WriteLine("X key = DISABLE");
            Console.WriteLine("ESC key = EXIT\n");
            Console.Write("NoJump is currently ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("DISABLED.");
            Console.ForegroundColor = ConsoleColor.Gray;

            do
            {
                while (Console.KeyAvailable == false)
                    Thread.Sleep(50); // Loop until input is entered.
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Z)
                {
                    invalidKey = false;
                    enabled = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (cki.Key == ConsoleKey.X)
                {
                    invalidKey = false;
                    enabled = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    invalidKey = true;
                    Console.WriteLine("\nInvalid key.");
                }

                if (enabled && invalidKey == false)
                {
                    Console.WriteLine("\nNoJump is ENABLED.");
                }
                else if (enabled == false && invalidKey == false)
                {
                    Console.WriteLine("\nNoJump is DISABLED.");
                }
            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}