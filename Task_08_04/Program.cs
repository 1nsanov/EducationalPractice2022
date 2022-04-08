using Helper;
using Task_08_04;

class Program
{
    private static bool _switch = true;
    private static HashTableCalls? hashTableCalls;
    static void Main(string[] args)
    {
        hashTableCalls = new HashTableCalls();
        dataSource.WrapperSwitcher(ref _switch, "Q - Add record | W - Output Table | E - Write to file | R - Read from file | T - Exit", SelectorUISwitch);
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
                dataSource.WrapperSwitchAction(WriteToFile);
                break;
            case ConsoleKey.R:
                dataSource.WrapperSwitchAction(ReadFromFile);
                break;
            case ConsoleKey.T:
                dataSource.ExitFromSwitch(ref _switch);
                break;
            default:
                dataSource.CommandNotFound();
                break;
        }
    }

    private static void WriteToFile()
    {
        hashTableCalls?.WriteToFile();
    }

    private static void ReadFromFile()
    {
        var success = hashTableCalls?.ReadFromFile();
        if ((bool)success) OutputTable();
    }

    private static void AddRecord()
    {
        hashTableCalls?.AddRecord();
    }
    private static void OutputTable()
    {
        hashTableCalls?.OutputHashTable();
        hashTableCalls?.OutputList();
    }
}
