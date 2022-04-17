using Helper;
using Task_06_04;

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
        var gragh = InitGragh();
        DrawMatrix(gragh);
        Console.WriteLine("List paths: ");
        gragh.PrintEdges();
        CheckOnExistPath(gragh);
    }

    private static Graph InitGragh()
    {
        var gragh = new Graph();
        var rnd = new Random();
        var v1 = new Vertex(1, "Москва");
        var v2 = new Vertex(2, "Тирасполь");
        var v3 = new Vertex(3, "Киев");
        var v4 = new Vertex(4, "Кишинев");
         
        gragh.AddVertex(v1);
        gragh.AddVertex(v2);
        gragh.AddVertex(v3);
        gragh.AddVertex(v4);

        gragh.AddEdge(v1, v2, rnd.Next(10, 99));
        gragh.AddEdge(v2, v4, rnd.Next(10, 99));
        gragh.AddEdge(v4, v3, rnd.Next(10, 99));
        gragh.AddEdge(v2, v3, rnd.Next(10, 99));
        gragh.AddEdge(v1, v4, rnd.Next(10, 99));
        gragh.AddEdge(v1, v3, rnd.Next(10, 99));
        return gragh;
    }

    private static void CheckOnExistPath(Graph gragh)
    {
        Console.WriteLine("Input start city");
        var startCity = Console.ReadLine();
        Console.WriteLine("Input end city");
        var endCity = Console.ReadLine();
        var startVertex = gragh.Vertexes.Find(x => x.NameCity == startCity);
        var endVertex = gragh.Vertexes.Find(x => x.NameCity == endCity);
        if (startCity == null || endCity == null) Console.WriteLine("Input correct city...");
        else
        {
            if (gragh.Wave(startVertex, endVertex)) Console.WriteLine("Path is exist");
            else Console.WriteLine("Path is not exist");
        }
    }

    private static void DrawMatrix(Graph gragh)
    {
        var matrix = gragh.GetMatrix();
        for (int i = 0; i < gragh.VertexCount; i++)
        {
            Console.Write(i + 1);
            for (int j = 0; j < gragh.VertexCount; j++)
            {
                Console.Write(" |" + matrix[i, j] + "| \t");
            }
            Console.WriteLine();
        }
        Console.WriteLine(" _________________________________________________");
        for (int i = 0; i < gragh.VertexCount; i++)
        {
            Console.Write($" |{i + 1}| \t");
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}