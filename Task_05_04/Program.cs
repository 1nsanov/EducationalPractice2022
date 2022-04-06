using Helper;
using Task_05_04;

class Program
{
    private static HexadecimalCounter? HexNumber = null;
    private static bool _switch = true;
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        while (_switch)
        {
            Console.WriteLine("Q - Create default number | W - create custom number | E - Increment | R - Decrement | T - Print | Y - Exit");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    CreateDefaultNumber();
                    break;
                case ConsoleKey.W:
                    CreateCustomNumber();
                    break;
                case ConsoleKey.E:
                    Increment();
                    break;
                case ConsoleKey.R:
                    Decrement();
                    break;
                case ConsoleKey.T:
                    Print();
                    break;
                case ConsoleKey.Y:
                    dataSource.ExitFromSwitch(ref _switch);
                    break;
                default:
                    dataSource.CommandNotFound();
                    break;
            }
        }
    }

    private static void CreateDefaultNumber()
    {
        dataSource.WrapperUIAction(() => {
            HexNumber = new HexadecimalCounter();
            HexNumber.PrintValues();
        });
    }

    private static void CreateCustomNumber()
    {
        dataSource.WrapperUIAction(() =>
        {
            HexNumber = HexadecimalCounter.SetValue();
            HexNumber.PrintValues();
        });
    }

    private static void Increment()
    {
        dataSource.WrapperUIAction(() =>
        {
            HexNumber?.Increment();
            if (HexNumber == null) MessageOnNull();
        });
    }

    private static void Decrement()
    {
        dataSource.WrapperUIAction(() =>
        {
            HexNumber?.Decrement();
            if (HexNumber == null) MessageOnNull();
        });
    }

    private static void Print()
    {
        dataSource.WrapperUIAction(() =>
        {
            HexNumber?.PrintValues();
            if (HexNumber == null) MessageOnNull();
        });
    }
    private static void MessageOnNull()
    {
        Console.WriteLine("You must create a number first");
    }
}