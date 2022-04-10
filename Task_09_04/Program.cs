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
                dataSource.WrapperSwitchAction(_listRoutesBuses.OutputRoutesBuses);
                SelectorUISwitch();
                break;
            case ConsoleKey.W:
                dataSource.WrapperSwitchAction(_listRoutesBuses.WriteToFile);
                SelectorUISwitch();
                break;
            case ConsoleKey.E:
                dataSource.WrapperSwitchAction(_listRoutesBuses.ReadFromFile);
                SelectorUISwitch();
                break;
            case ConsoleKey.R:
                dataSource.WrapperSwitchAction(_listRoutesBuses.GetCountUrabanBus);
                SelectorUISwitch();
                break;
            case ConsoleKey.T:
                dataSource.WrapperSwitchAction(_listRoutesBuses.GetRouteById);
                SelectorUISwitch();
                break;
            case ConsoleKey.Y:
                dataSource.WrapperSwitchAction(_listRoutesBuses.GetBusesIdByCity);
                SelectorUISwitch();
                break;
            case ConsoleKey.U:
                dataSource.WrapperSwitchAction(_listRoutesBuses.GetRoutesByBusBaseId);
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
}