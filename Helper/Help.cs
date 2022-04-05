namespace Helper
{
    public class Help
    {
        public static int ParseInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value)) { return value; }
                Console.WriteLine("Неверный формат. Повторите попытку.");
            }
        }

        public static double ParseDouble()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double value)) { return value; }
                Console.WriteLine("Неверный формат. Повторите попытку.");
            }
        }

        public static void StopperConsole()
        {
            Console.WriteLine("Нажмите для продолжения...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
