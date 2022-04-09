using Helper;
using Task_09_04;

class Program
{
    private static ListRoutesBuses _listRoutesBuses = new();
    static void Main(string[] args)
    {
        _listRoutesBuses = new ListRoutesBuses();
        SelectorUISwitch();
    }

    private static void SelectorUISwitch()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
        Console.WriteLine("Q - Output routes buses | W - Write to file | E - Read from file | R - Get count city bus | T - Get way by id | Y - Get number by place | U - Get ways by Bus base | I - Exit");
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.Q:
                dataSource.WrapperSwitchAction(OutputRoutesBuses);
                SelectorUISwitch();
                break;
            case ConsoleKey.W:
                dataSource.WrapperSwitchAction(WriteToFile);
                SelectorUISwitch();
                break;
            case ConsoleKey.E:
                dataSource.WrapperSwitchAction(ReadFromFile);
                SelectorUISwitch();
                break;
            case ConsoleKey.R:
                dataSource.WrapperSwitchAction(GetCountUrabanBus);
                SelectorUISwitch();
                break;
            case ConsoleKey.T:
                dataSource.WrapperSwitchAction(GetRouteById);
                SelectorUISwitch();
                break;
            case ConsoleKey.Y:
                dataSource.WrapperSwitchAction(GetBusesIdByCity);
                SelectorUISwitch();
                break;
            case ConsoleKey.U:
                dataSource.WrapperSwitchAction(GetRoutesByBusBaseId);
                SelectorUISwitch();
                break;
            case ConsoleKey.I:
                break;
            default:
                dataSource.CommandNotFound();
                SelectorUISwitch();
                break;
        }
    }

    private static void OutputRoutesBuses()
    {
        _listRoutesBuses.OutputRoutesBuses();
    }

    private static void WriteToFile()
    {
        _listRoutesBuses.WriteToFile();
    }

    private static void ReadFromFile()
    {
        _listRoutesBuses.ReadFromFile();
    }

    private static void GetCountUrabanBus()
    {
        _listRoutesBuses.GetCountUrabanBus();
    }

    private static void GetRouteById()
    {
        _listRoutesBuses.GetRouteById();
    }

    private static void GetBusesIdByCity()
    {
        _listRoutesBuses.GetBusesIdByCity();
    }

    private static void GetRoutesByBusBaseId()
    {
        _listRoutesBuses.GetRoutesByBusBaseId();
    }
}