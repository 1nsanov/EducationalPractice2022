using Helper;
using Task_05_04;

class Program
{
    private static HexadecimalCounter? HexNumber = null;
    private static bool _switch = true;
    static void Main(string[] args)
    {
        dataSource.WrapperSwitcher(ref _switch,
                                   "Q - Create default number | W - create custom number | E - Increment | R - Decrement | T - Print | Y - Exit",
                                   SelectorUISwitch);
    }

    private static void SelectorUISwitch()
    {
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.Q:
                dataSource.WrapperSwitchAction(CreateDefaultNumber);
                break;
            case ConsoleKey.W:
                dataSource.WrapperSwitchAction(CreateCustomNumber);
                break;
            case ConsoleKey.E:
                dataSource.WrapperSwitchAction(Increment);
                break;
            case ConsoleKey.R:
                dataSource.WrapperSwitchAction(Decrement);
                break;
            case ConsoleKey.T:
                dataSource.WrapperSwitchAction(Print);
                break;
            case ConsoleKey.Y:
                dataSource.ExitFromSwitch(ref _switch);
                break;
            default:
                dataSource.CommandNotFound();
                break;
        }
    }

    private static void CreateDefaultNumber()
    {
        HexNumber = new HexadecimalCounter();
        HexNumber.PrintValues();
    }

    private static void CreateCustomNumber()
    {
        HexNumber = HexadecimalCounter.SetValue();
        HexNumber.PrintValues();
    }

    private static void Increment()
    {
        HexNumber?.Increment();
        if (HexNumber == null) MessageOnNull();
    }

    private static void Decrement()
    {
        HexNumber?.Decrement();
        if (HexNumber == null) MessageOnNull();
    }

    private static void Print()
    {
        HexNumber?.PrintValues();
        if (HexNumber == null) MessageOnNull();
    }
    private static void MessageOnNull()
    {
        Console.WriteLine("You must create a number first");
    }
}