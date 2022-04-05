using Helper;
using Task_05_04;

class Program
{
    private static HexadecimalCounter? HexNumber = null;
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        var swicth = true;
        while (swicth)
        {
            Console.WriteLine("Q - Create number default | W - create custom number | E - Increment | R - Decrement | T - Print | Y - Exit");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    Console.Clear();
                    HexNumber = new HexadecimalCounter();
                    HexNumber.PrintValues();
                    Help.StopperConsole();
                    break;
                case ConsoleKey.W:
                    Console.Clear();
                    HexNumber = HexadecimalCounter.SetValue();
                    HexNumber.PrintValues();
                    Help.StopperConsole();
                    break;
                case ConsoleKey.E:
                    Console.Clear();
                    HexNumber?.Increment();
                    Help.StopperConsole();
                    break;
                case ConsoleKey.R:
                    Console.Clear();
                    HexNumber?.Decrement();
                    Help.StopperConsole();
                    break;
                case ConsoleKey.T:
                    Console.Clear();
                    HexNumber?.PrintValues();
                    Help.StopperConsole();
                    break;
                case ConsoleKey.Y:
                    swicth = false;
                    break;
                default:
                    Console.WriteLine("Такой команды не существует");
                    break;
            }
        }
    }
}