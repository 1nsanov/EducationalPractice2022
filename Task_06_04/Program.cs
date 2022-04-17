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
        var rnd = new Random();

        var gragh = new Graph();

        var v1 = new Vertex(1);
        var v2 = new Vertex(2);
        var v3 = new Vertex(3);
        var v4 = new Vertex(4);
        var v5 = new Vertex(5);
        var v6 = new Vertex(6);
        var v7 = new Vertex(7);

        gragh.AddVertex(v1);
        gragh.AddVertex(v2);
        gragh.AddVertex(v3);
        gragh.AddVertex(v4);
        gragh.AddVertex(v5);
        gragh.AddVertex(v6);
        gragh.AddVertex(v7);

        gragh.AddEdge(v1, v2, rnd.Next(0, 99));
        gragh.AddEdge(v1, v3, rnd.Next(0, 99));
        gragh.AddEdge(v3, v4, rnd.Next(0, 99));
        gragh.AddEdge(v2, v5, rnd.Next(0, 99));
        gragh.AddEdge(v2, v6, rnd.Next(0, 99));
        gragh.AddEdge(v6, v5, rnd.Next(0, 99));
        gragh.AddEdge(v5, v6, rnd.Next(0, 99));

        DrawMatrix(gragh);

        GetVertex(gragh, v1);
        GetVertex(gragh, v2);
        GetVertex(gragh, v3);
        GetVertex(gragh, v4);
        GetVertex(gragh, v5);
        GetVertex(gragh, v6);
        GetVertex(gragh, v7);

        Console.WriteLine(gragh.Wave(v1, v5));
        Console.WriteLine(gragh.Wave(v2, v4));
    }

    private static void GetVertex(Graph gragh, Vertex vertex)
    {
        Console.Write(vertex.Number + ": ");
        foreach (var item in gragh.GetVertexLists(vertex))
        {
            Console.Write(item.Number + ", ");
        }
        Console.WriteLine();
    }

    private static void DrawMatrix(Graph gragh)
    {
        var matrix = gragh.GetMatrix();
        for (int i = 0; i < gragh.VertexCount; i++)
        {
            Console.Write(i + 1);
            for (int j = 0; j < gragh.EdgesCount; j++)
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