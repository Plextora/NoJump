using Memory;

namespace NoJump
{
    internal class Program
    {

        static Mem memoryManager = new Mem();

        static void Main(string[] args)
        {
            bool enabled = false;
            bool invalidKey = false;
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            Console.ForegroundColor = ConsoleColor.Gray;
            memoryManager.OpenProcess("Minecraft.Windows");


            void ActivateNoJump()
            {
                memoryManager.WriteMemory("Minecraft.Windows.exe+3A22638", "float", "-1000");
            }

            void DisableNoJump()
            {
                memoryManager.WriteMemory("Minecraft.Windows.exe+3A22638", "float", "3");
            }

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
                    ActivateNoJump();
                    invalidKey = false;
                    enabled = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (cki.Key == ConsoleKey.X)
                {
                    DisableNoJump();
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

            memoryManager.CloseProcess();
        }
    }
}