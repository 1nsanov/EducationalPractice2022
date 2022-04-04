namespace Helper
{
    public class Help
    {
        public static int ParseInt()
        {
            string? value;
            while (true)
            {
                value = Console.ReadLine();
                if (int.TryParse(value, out int val)) { return val; }
                Console.WriteLine("Неверный формат. Повторите попытку.");
            }
        }

        public static double ParseDouble()
        {
            string? value;
            while (true)
            {
                value = Console.ReadLine();
                if (double.TryParse(value, out double val)) { return val; }
                Console.WriteLine("Неверный формат. Повторите попытку.");
            }
        }
    }
}
