namespace Helper
{
    public class dataSource
    {
        /// <summary>
        /// Обертка для консольных команд в кейсах switch
        /// </summary>
        /// <param name="action">Метод</param>
        public static void WrapperSwitchAction(Action action)
        {
            Console.Clear();
            action?.Invoke();
            StopperConsole();
        }

        /// <summary>
        /// Обертка для switch
        /// </summary>
        /// <param name="switcher">Переключатель</param>
        /// <param name="description">Описание команд</param>
        /// <param name="action">Метод</param>
        public static void WrapperSwitcher(ref bool switcher, string description, Action action)
        {
            while (switcher)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(description);
                action?.Invoke();
            }
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
        /// Конверт в int с проверкой на валидность для форм
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int ParseIntForm(string number)
        {
            if (int.TryParse(number, out int value)) return value;
            else throw new Exception("Incorrect input. Try again.");
        }


        /// <summary>
        /// Конверт в DateTime с проверкой на валидность
        /// </summary>
        /// <returns></returns>
        public static DateTime ParseDateTime()
        {
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out DateTime value)) { Console.ForegroundColor = ConsoleColor.Green; return value; }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input. Try again.");
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }
        /// <summary>
        /// Проверка на пустую строку
        /// </summary>
        /// <returns></returns>
        public static string ParseString()
        {
            while (true)
            {
                var line = Console.ReadLine();
                if (!string.IsNullOrEmpty(line)) { Console.ForegroundColor = ConsoleColor.Green; return line; }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input. String can't be empty. Try again.");
                Console.ForegroundColor = ConsoleColor.Green;
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
            WrapperSwitchAction(() =>
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
