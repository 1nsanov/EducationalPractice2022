namespace Helper
{
    public class dataSource
    {
        /// <summary>
        /// Обертка для консольных команд в кейсах свича
        /// </summary>
        /// <param name="action">Выполняемый код</param>
        public static void WrapperUIAction(Action action)
        {
            Console.Clear();
            action?.Invoke();
            StopperConsole();
        }
        /// <summary>
        /// Конверт в int с проверкой на валидность
        /// </summary>
        /// <returns></returns>
        public static int ParseInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value)) { Console.ForegroundColor = ConsoleColor.Green; return value; }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input. Try again.");
                Console.ForegroundColor = ConsoleColor.Green;
            }

        }
        /// <summary>
        /// Конверт в double с проверкой на валидность
        /// </summary>
        /// <returns></returns>
        public static double ParseDouble()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double value)) { return value; }
                Console.WriteLine("Incorrect input. Try again.");
            }
        }
        /// <summary>
        /// Ожидание нажатия для продолжения
        /// </summary>
        public static void StopperConsole()
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ForegroundColor = ConsoleColor.Black;
            while (true) if (Console.ReadKey().Key == ConsoleKey.Enter) break;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
        }
        /// <summary>
        /// Сообщение о невозможности выполнения команды
        /// </summary>
        public static void CommandNotFound()
        {
            WrapperUIAction(() =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Command not found...");
                Console.ForegroundColor = ConsoleColor.Green;
            });
        }
        /// <summary>
        /// Выход из switch
        /// </summary>
        /// <param name="exit"></param>
        public static void ExitFromSwitch(ref bool exit)
        {
            Console.Clear();
            exit = false;
        }
    }
}
