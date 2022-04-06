using Helper;
using Task_04_04;

class Program
{
    private static bool _switch = true;
    static void Main(string[] args)
    {
        dataSource.WrapperSwitcher(ref _switch, "Q - Create line | W - Exit", SelectorUISwitch);
    }

    private static void SelectorUISwitch()
    {
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.Q:
                dataSource.WrapperSwitchAction(CreateLine);
                break;
            case ConsoleKey.W:
                dataSource.ExitFromSwitch(ref _switch);
                break;
            default:
                dataSource.CommandNotFound();
                break;
        }
    }

    private static void CreateLine()
    {
        var line = new Line();
        line.SetPoints();
        line.GetСoefficientStraight();
    }
}
