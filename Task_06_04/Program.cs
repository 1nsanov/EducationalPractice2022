using Helper;

class Program
{
    private static bool _switch = true;
    static void Main(string[] args)
    {
        dataSource.WrapperSwitcher(ref _switch, "Q - Start task| W - Exit", SelectorUISwitch);
    }

    private static void SelectorUISwitch()
    {
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.Q:
                dataSource.WrapperSwitchAction(StartTask);
                break;
            case ConsoleKey.W:
                dataSource.ExitFromSwitch(ref _switch);
                break;
            default:
                dataSource.CommandNotFound();
                break;
        }
    }

    private static void StartTask()
    {
        Console.WriteLine("Задание не решено по причине излишней сложности.");
    }
}