using Helper;
using Task_07_04;

class Program
{
    private static bool _switch = true;
    private static HashTableCalls? hashTableCalls;
    static void Main(string[] args)
    {
        hashTableCalls = new HashTableCalls();
        dataSource.WrapperSwitcher(ref _switch, "Q - Add record | W - Output Table | E - Exit", SelectorUISwitch);
    }

    private static void SelectorUISwitch()
    {
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.Q:
                dataSource.WrapperSwitchAction(AddRecord);
                break;
            case ConsoleKey.W:
                dataSource.WrapperSwitchAction(OutputTable);
                break;
            case ConsoleKey.E:
                dataSource.ExitFromSwitch(ref _switch);
                break;
            default:
                dataSource.CommandNotFound();
                break;
        }
    }
    
    private static void AddRecord()
    {
}
    private static void OutputTable()
    {
        hashTableCalls?.OutputHashTable();
        hashTableCalls?.OutputList();
        if (hashTableCalls == null) { Console.WriteLine("Table is null"); }
    }


}