using Helper;
using Task_04_04;

class Program
{
    private static bool _switch = true;
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        while (_switch)
        {
            Console.WriteLine("Q - Create line | W - Exit");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    CreateLine();
                    break;
                case ConsoleKey.W:
                    dataSource.ExitFromSwitch(ref _switch);  
                    break;
                default:
                    dataSource.CommandNotFound();
                    break;
            }
        }
    }
    private static void CreateLine()
    {
        dataSource.WrapperUIAction(() =>
        {
            var line = new Line();
            line.SetPoints();
            line.GetСoefficientStraight();
        });
    }
}
